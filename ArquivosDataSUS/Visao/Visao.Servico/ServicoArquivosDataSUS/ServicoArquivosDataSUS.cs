using ArquivosDataSUS;
using Domain.Entity;
using Infrastructure.Common;
using Quartz;
using Quartz.Impl;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace ServicoArquivosDataSUS
{
    public partial class ServicoArquivosDataSUS : ServiceBase, IJob
    {
        private IScheduler scheduler = null;
        private static bool emExecucao = false;

        private string servidorFTP;
        private string usuarioFTP;
        private string senhaFTP;
        private string diretorioFTP_RD;
        private string diretorioFTP_RJ;
        private string diretorioFTP_PA;

        private string diretorioDestinoDownload;
        private string diretorioDestinoDBF;
        private string tipoArquivos;
        private string uF;

        private int diaAgendamento;
        private int hora;
        private int minuto;
        private int executarAcadaMinuto;

        public ServicoArquivosDataSUS()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            RegistroLog.RegistarLogInfo("##################################################################################");

            RegistroLog.RegistarLogInfo(Mensagem.ServicoInicio);

            this.CarregarConfiguracoes();
            this.DefinirAgendamentoExecucao();

            RegistroLog.RegistarLogInfo(Mensagem.ServicoFim);

            RegistroLog.RegistarLogInfo("##################################################################################");

        }

        public void InicioParaDebug()
        {
            RegistroLog.RegistarLogInfo(Mensagem.ServicoInicio);

            this.CarregarConfiguracoes();
            this.DefinirAgendamentoExecucao();

            RegistroLog.RegistarLogInfo(Mensagem.ServicoFim);
        }

        protected override void OnStop()
        {
            this.scheduler.Clear();
            RegistroLog.RegistarLogInfo(Mensagem.ServicoStop);
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                RegistroLog.RegistarLogInfo("***************************************************************************************************************");

                if (emExecucao)
                {
                    RegistroLog.RegistarLogInfo(Mensagem.ServicoInicio);
                    RegistroLog.RegistarLogInfo(Mensagem.ServicoUltimaExecucao + " (" + context.FireTimeUtc.Value.LocalDateTime.ToString(Constantes.FormatoDataHora) + ")");
                    RegistroLog.RegistarLogInfo(Mensagem.ServicoProximaExecucao + " (" + context.NextFireTimeUtc.Value.LocalDateTime.ToString(Constantes.FormatoDataHora) + ")");
                }
                else
                {
                    this.CarregarConfiguracoes();

                    //Inicia a o tratamento dos arquivos.
                   this.IniciarExecucao(context.FireTimeUtc.Value.LocalDateTime, context.NextFireTimeUtc.Value.LocalDateTime);

                }
                RegistroLog.RegistarLogInfo("***************************************************************************************************************");

            }
            catch (Exception ex)
            {
                BaseAquivosDataSUS.SalvarLogErroAplicacao(ex);
            }
        }

        private void DefinirAgendamentoExecucao()
        {
            RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoInicio);

            ISchedulerFactory schedFact = new StdSchedulerFactory();
            ITrigger trigger;

            this.scheduler = schedFact.GetScheduler();

            IJobDetail job = JobBuilder.Create<ServicoArquivosDataSUS>()
                .WithIdentity("JobServico", "groupServico")
                .Build();


            if (this.executarAcadaMinuto > 0)
            {
                trigger = TriggerBuilder.Create()
                                      .StartNow()
                                      .WithSchedule(SimpleScheduleBuilder.RepeatMinutelyForever(this.executarAcadaMinuto))
                                      .Build();
            }
            else
            {
                CronScheduleBuilder cronScheduleBuilder;

                Enumeradores.DiaDaSemana dia = Enumeradores.ConverterObject2DiaDaSemana(this.diaAgendamento);

                if (dia == Enumeradores.DiaDaSemana.AllDays)
                    cronScheduleBuilder = CronScheduleBuilder.DailyAtHourAndMinute(this.hora, this.minuto);
                else
                    cronScheduleBuilder = CronScheduleBuilder.WeeklyOnDayAndHourAndMinute((DayOfWeek)dia, this.hora, this.minuto);

                trigger = TriggerBuilder.Create()
                                            .StartNow()
                                            .WithSchedule(cronScheduleBuilder)
                                            .Build();
            }

            this.scheduler.ScheduleJob(job, trigger);
            this.scheduler.Start();

            RegistroLog.RegistarLogInfo(Mensagem.ServicoProximaExecucao + " - " + trigger.GetNextFireTimeUtc().Value.LocalDateTime.ToString(Constantes.FormatoDataHora));

            RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoFim);

        }

        private void CarregarConfiguracoes()
        {

            RegistroLog.RegistarLogInfo(Mensagem.ArqConfiObtendoInfo);

            this.servidorFTP = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppServidorFTP);
            this.usuarioFTP = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppUsuarioServidorOrigemFTP);
            this.senhaFTP = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppSenhaUsuarioServidorOrigemFTP);

            this.diretorioFTP_RD = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_RD);
            this.diretorioFTP_RJ = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_RJ);
            this.diretorioFTP_PA = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_PA);

            this.diretorioDestinoDownload = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioDestinoArquivosFTP);
            this.diretorioDestinoDBF = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioDestinoArquivosDBF);

            this.uF = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppUFArquivosDownload);
            this.diaAgendamento = Convert.ToInt32(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppFrequenciaExecucao));
            this.hora = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppHoraExecucao));
            this.minuto = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppMinutoExecucao));
            this.tipoArquivos = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppTiposArquivos);

            this.executarAcadaMinuto = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppExecucaoAcadaMinutos));

            RegistroLog.RegistarLogInfo(Mensagem.ArqConfiObterInfoSucesso);
        }

        private void IniciarExecucao(DateTime ultimaExcucao, DateTime proximaExecucao)
        {
            emExecucao = true;

            Stopwatch tempoExecucao = new Stopwatch();

            tempoExecucao.Start();

            RegistroLog.RegistarLogInfo(Mensagem.ServicoInicio);

            if (this.tipoArquivos.Contains(Constantes.TipoArquivoRD))
            {
                try
                {
                    this.BuscarArquivosRD();
                }
                catch (Exception ex)
                {
                    BaseAquivosDataSUS.SalvarLogErroAplicacao(Mensagem.ArqFalhaRD, ex);
                }
            }

            if (this.tipoArquivos.Contains(Constantes.TipoArquivoRJ))
            {
                try
                {
                    this.BuscarArquivosRJ();
                }
                catch (Exception ex)
                {
                    BaseAquivosDataSUS.SalvarLogErroAplicacao(Mensagem.ArqFalhaRJ, ex);
                }
            }

            if (this.tipoArquivos.Contains(Constantes.TipoArquivoPA))
            {
                try
                {
                    this.BuscarArquivosPA();
                }
                catch (Exception ex)
                {
                    BaseAquivosDataSUS.SalvarLogErroAplicacao(Mensagem.ArqFalhaPA, ex);
                }
            }

            RegistroLog.RegistarLogInfo("-----------------------------------------------------------------------------------------------");

            RegistroLog.RegistarLogInfo(Mensagem.ServicoUltimaExecucao + " - " + ultimaExcucao.ToString(Constantes.FormatoDataHora));
            RegistroLog.RegistarLogInfo(Mensagem.ServicoProximaExecucao + " - " + proximaExecucao.ToString(Constantes.FormatoDataHora));

            RegistroLog.RegistarLogInfo("-----------------------------------------------------------------------------------------------");

            tempoExecucao.Stop();

            RegistroLog.RegistarLogInfo(Mensagem.ServicoTempoExecucao + " - " + tempoExecucao.Elapsed.ToString());

            emExecucao = false;

            RegistroLog.RegistarLogInfo("-----------------------------------------------------------------------------------------------");

        }

        private void BuscarArquivosRD()
        {

            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaRD + "-----------------");

            ArquivosRDDataSUS arquivosRDDataSUS = new ArquivosRDDataSUS(this.servidorFTP.Trim(), this.usuarioFTP.Trim(), this.senhaFTP.Trim(), this.diretorioFTP_RD.Trim(), this.diretorioDestinoDownload.Trim(), this.diretorioDestinoDBF.Trim(), this.uF.Trim());
            arquivosRDDataSUS.BuscarArquivosFTP();
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaRD);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosRDDataSUS.BuscarArquivosBanco();
            arquivosRDDataSUS.VerificarNovosArquivosFTP();
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            arquivosRDDataSUS.VerificarArquivosModificados();
            //
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosRDDataSUS.DownloadArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosRDDataSUS.ConverterArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosRDDataSUS.SalvarArquivoBanco();
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaFimBD);
            //
            //Lista os arquivos que não existem mais no servidor.
            if (arquivosRDDataSUS.ListaArquivosFalhaModificados.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqNaoEncontrado);
                foreach (Arquivo item in arquivosRDDataSUS.ListaArquivosFalhaModificados)
                {
                    RegistroLog.RegistarLogInfo(item.Nome);
                }
            }
            //Lista os arquivos com falha no download
            if (arquivosRDDataSUS.ListaArquivosFalhaDownload.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.DownloadFalha);
                foreach (string item in arquivosRDDataSUS.ListaArquivosFalhaDownload)
                {
                    RegistroLog.RegistarLogInfo(item);
                }
            }
            //Lista os arquivos com falha na conversão.
            if (arquivosRDDataSUS.ListaArquivosFalhaConversaoDBF.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqFalhaConversao);
                foreach (Arquivo item in arquivosRDDataSUS.ListaArquivosFalhaConversaoDBF)
                {
                    RegistroLog.RegistarLogInfo(Constantes.FormartarInfoLogArquivo(item));
                }
            }
        }

        private void BuscarArquivosRJ()
        {

            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaRJ + "-----------------");
            ArquivosRJDataSUS arquivosRJDataSUS = new ArquivosRJDataSUS(this.servidorFTP.Trim(), this.usuarioFTP.Trim(), this.senhaFTP.Trim(), this.diretorioFTP_RJ.Trim(), this.diretorioDestinoDownload.Trim(), this.diretorioDestinoDBF.Trim(), this.uF.Trim());
            arquivosRJDataSUS.BuscarArquivosFTP();
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaRJ);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosRJDataSUS.BuscarArquivosBanco();
            arquivosRJDataSUS.VerificarNovosArquivosFTP();
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            arquivosRJDataSUS.VerificarArquivosModificados();
            //
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosRJDataSUS.DownloadArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosRJDataSUS.ConverterArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosRJDataSUS.SalvarArquivoBanco();
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaFimBD);
            //
            //Lista os arquivos que não existem mais no servidor.
            if (arquivosRJDataSUS.ListaArquivosFalhaModificados.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqNaoEncontrado);
                foreach (Arquivo item in arquivosRJDataSUS.ListaArquivosFalhaModificados)
                {
                    RegistroLog.RegistarLogInfo(item.Nome);
                }
            }
            //Lista os arquivos com falha no download
            if (arquivosRJDataSUS.ListaArquivosFalhaDownload.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.DownloadFalha);
                foreach (string item in arquivosRJDataSUS.ListaArquivosFalhaDownload)
                {
                    RegistroLog.RegistarLogInfo(item);
                }
            }
            //Lista os arquivos com falha na conversão.
            if (arquivosRJDataSUS.ListaArquivosFalhaConversaoDBF.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqFalhaConversao);
                foreach (Arquivo item in arquivosRJDataSUS.ListaArquivosFalhaConversaoDBF)
                {
                    RegistroLog.RegistarLogInfo(Constantes.FormartarInfoLogArquivo(item));
                }
            }
        }

        private void BuscarArquivosPA()
        {

            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaPA + "-----------------");
            ArquivosPADataSUS arquivosPADataSUS = new ArquivosPADataSUS(this.servidorFTP.Trim(), this.usuarioFTP.Trim(), this.senhaFTP.Trim(), this.diretorioFTP_PA.Trim(), this.diretorioDestinoDownload.Trim(), this.diretorioDestinoDBF.Trim(), this.uF.Trim());
            arquivosPADataSUS.BuscarArquivosFTP();
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaPA);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosPADataSUS.BuscarArquivosBanco();
            arquivosPADataSUS.VerificarNovosArquivosFTP();
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            arquivosPADataSUS.VerificarArquivosModificados();
            //
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosPADataSUS.DownloadArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosPADataSUS.ConverterArquivos();
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosPADataSUS.SalvarArquivoBanco();
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaFimBD);
            
            //Lista os arquivos que não existem mais no servidor.
            if (arquivosPADataSUS.ListaArquivosFalhaModificados.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqNaoEncontrado);
                foreach (Arquivo item in arquivosPADataSUS.ListaArquivosFalhaModificados)
                {
                    RegistroLog.RegistarLogInfo(item.Nome);
                }
            }
            //Lista os arquivos com falha no download
            if (arquivosPADataSUS.ListaArquivosFalhaDownload.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.DownloadFalha);
                foreach (string item in arquivosPADataSUS.ListaArquivosFalhaDownload)
                {
                    RegistroLog.RegistarLogInfo(item);
                }
            }
            //Lista os arquivos com falha na conversão.
            if (arquivosPADataSUS.ListaArquivosFalhaConversaoDBF.Count > 0)
            {
                RegistroLog.RegistarLogInfo(Mensagem.ArqFalhaConversao);
                foreach (Arquivo item in arquivosPADataSUS.ListaArquivosFalhaConversaoDBF)
                {
                    RegistroLog.RegistarLogInfo(Constantes.FormartarInfoLogArquivo(item));
                }
            }
        }

    }
}
