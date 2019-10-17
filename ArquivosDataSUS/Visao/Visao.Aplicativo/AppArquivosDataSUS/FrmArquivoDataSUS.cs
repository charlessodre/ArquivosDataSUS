using Domain.Entity;
using Infrastructure.Common;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ArquivosDataSUS
{
    public partial class FrmArquivoDataSUS : BaseForm, IJob
    {
        public static FrmArquivoDataSUS formAtual = null;
        public delegate void AtualizaFormExecucao(IJobExecutionContext context);
        private IScheduler scheduler = null;
        private bool emExecucao = false;

        public FrmArquivoDataSUS()
        {
            InitializeComponent();
        }

        #region Eventos

        private void FrmListaBaixarArquivos_Load(object sender, EventArgs e)
        {
            try
            {
                FrmArquivoDataSUS.formAtual = this;
                this.PreencherComboFrequencia();
                this.CarregarConfiguracoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BaseAquivosDataSUS.SalvarLogErroAplicacao(ex);
            }
        }

        private void FrmArquivoDataSUS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!base.FecharFormulario)
            {
                if (base.ExibirMessagemGeral(Mensagem.SistemaSair, TituloJanelas.SairSistema,
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    base.FecharFormulario = true;

                    FrmArquivoDataSUS.formAtual.Close();
                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }


        private void FrmArquivoDataSUS_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();
        }

        private void IcNotificacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Opacity = 100;
            this.Show();
        }

        private void btnEscolherDiretorioDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldDlg = new FolderBrowserDialog();

            if (fldDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtDiretorioDestinoDownload.Text = fldDlg.SelectedPath;
            }
        }

        private void btnDestinoDBF_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldDlg = new FolderBrowserDialog();

            if (fldDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtDestinoDBF.Text = fldDlg.SelectedPath;
            }
        }

        private void cbxAcadaMinuto_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxAcadaMinuto.Enabled = this.cbxAcadaMinuto.Checked;
            this.ddlDiaAgendamento.Enabled = !this.cbxAcadaMinuto.Checked;
            this.nudHora.Enabled = !this.cbxAcadaMinuto.Checked;
            this.nudMinuto.Enabled = !this.cbxAcadaMinuto.Checked;
        }

        private void gerarConfiguraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmBaixarArquivos frmConfig = new FrmBaixarArquivos();
            frmConfig.ShowDialog();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSobre frmSobre = new FrmSobre();
            frmSobre.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblProximaExecucao_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lblUltimaExecucao_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lblExecucao_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lblStatusApp_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lblBarraStatus_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void btnExecutarAgora_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                try
                {
                    this.btnExecutarAgora.Enabled = this.btnAgendarExecucao.Enabled = false;
                    RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoInicio);
                    //
                    this.IniciarExecucao(DateTime.Now, DateTime.Now);
                    //
                    RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoFim);
                    this.btnExecutarAgora.Enabled = true;
                    this.btnAgendarExecucao.Enabled = (this.scheduler == null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    this.btnExecutarAgora.Enabled = this.btnAgendarExecucao.Enabled = true;
                    BaseAquivosDataSUS.SalvarLogErroAplicacao(ex);
                }
            }
        }

        private void btnAgendarExecucao_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                try
                {
                    this.btnExecutarAgora.Enabled = this.btnAgendarExecucao.Enabled = false;
                    //
                    this.DefinirAgendamentoExecucao();
                    //
                    this.btnExecutarAgora.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    this.btnExecutarAgora.Enabled = this.btnAgendarExecucao.Enabled = true;
                    BaseAquivosDataSUS.SalvarLogErroAplicacao(ex);
                }
            }
        }


        #endregion

        #region Métodos

        private void DefinirIcone()
        {
            if (this.emExecucao)
            {
                this.IcNotificacao.Icon = base.IconeEmExecucao;
            }
            else
            {
                this.IcNotificacao.Icon = base.PathIconeDefault;
            }
        }

        private void IniciarExecucao(DateTime ultimaExcucao, DateTime proximaExecucao)
        {
            this.emExecucao = true;

            this.DefinirIcone();

            this.lblBarraStatus.Text = Mensagem.SistemaInicio;

            Stopwatch tempoExecucao = new Stopwatch();

            tempoExecucao.Start();

            this.lblStatusApp.Text = Mensagem.SistemaEmExecucao;

            RegistroLog.RegistarLogInfo(Mensagem.SistemaInicio);

            //if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoRD))
            //    this.BuscarArquivosRD();
            //if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoRJ))
            //    this.BuscarArquivosRJ();
            //if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoPA))
            //    this.BuscarArquivosPA();

            if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoRD))
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

            if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoRJ))
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

            if (this.lblTipoArquivos.Text.Contains(Constantes.TipoArquivoPA))
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

            this.lblUltimaExecucao.Text = ultimaExcucao.ToString(Constantes.FormatoDataHora);
            this.lblProximaExecucao.Text = proximaExecucao.ToString(Constantes.FormatoDataHora);

            tempoExecucao.Stop();

            this.lblExecucao.Text = Constantes.FormartarTimeSpan(tempoExecucao.Elapsed);
            this.lblStatusApp.Text = Mensagem.SistemaAguardandoExecucao;

            RegistroLog.RegistarLogInfo(Mensagem.SistemaFim);
            RegistroLog.RegistarLogInfo(Mensagem.SistemaTempoExecucao + tempoExecucao.Elapsed.ToString());

            this.lblBarraStatus.Text = Mensagem.SistemaFim;

            RegistroLog.RegistarLogInfo("----------------------------------------------------------------------------------");

            this.emExecucao = false;

            this.DefinirIcone();
        }

        private void BuscarArquivosRD()
        {

            this.lblBarraStatus.Text = Mensagem.ArqBuscaIniciadaRD;
            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaRD + "-----------------");

            ArquivosRDDataSUS arquivosRDDataSUS = new ArquivosRDDataSUS(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim(), this.txtDiretorioFTP_RD.Text.Trim(), this.txtDiretorioDestinoDownload.Text.Trim(), this.txtDestinoDBF.Text.Trim(), this.lblUF.Text.Trim());
            arquivosRDDataSUS.BuscarArquivosFTP();
            this.lblBarraStatus.Text = Mensagem.ArqBuscaFinalizadaRD;
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaRD);

            //
            this.lblBarraStatus.Text = Mensagem.ArqVerifNovos;
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosRDDataSUS.BuscarArquivosBanco();
            arquivosRDDataSUS.VerificarNovosArquivosFTP();
            //
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            this.lblBarraStatus.Text = Mensagem.ArqVerifModificados;
            arquivosRDDataSUS.VerificarArquivosModificados();
            //
            this.lblBarraStatus.Text = Mensagem.DownloadInicio;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosRDDataSUS.DownloadArquivos();
            this.lblBarraStatus.Text = Mensagem.DownloadFim;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqConversaoInicio;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosRDDataSUS.ConverterArquivos();
            this.lblBarraStatus.Text = Mensagem.ArqConversaoFim;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqSalvaInicioBD;
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosRDDataSUS.SalvarArquivoBanco();
            this.lblBarraStatus.Text = Mensagem.ArqSalvaFimBD;
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

            this.lblBarraStatus.Text = Mensagem.ArqBuscaIniciadaRJ;
            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaRJ + "-----------------");
            ArquivosRJDataSUS arquivosRJDataSUS = new ArquivosRJDataSUS(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim(), this.txtDiretorioFTP_RJ.Text.Trim(), this.txtDiretorioDestinoDownload.Text.Trim(), this.txtDestinoDBF.Text.Trim(), this.lblUF.Text.Trim());
            arquivosRJDataSUS.BuscarArquivosFTP();
            this.lblBarraStatus.Text = Mensagem.ArqBuscaFinalizadaRJ;
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaRJ);
            //
            this.lblBarraStatus.Text = Mensagem.ArqVerifNovos;
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosRJDataSUS.BuscarArquivosBanco();
            arquivosRJDataSUS.VerificarNovosArquivosFTP();
            //
            this.lblBarraStatus.Text = Mensagem.ArqVerifModificados;
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            arquivosRJDataSUS.VerificarArquivosModificados();
            //
            this.lblBarraStatus.Text = Mensagem.DownloadInicio;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosRJDataSUS.DownloadArquivos();
            this.lblBarraStatus.Text = Mensagem.DownloadFim;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqConversaoInicio;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosRJDataSUS.ConverterArquivos();
            this.lblBarraStatus.Text = Mensagem.ArqConversaoFim;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqSalvaInicioBD;
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosRJDataSUS.SalvarArquivoBanco();
            this.lblBarraStatus.Text = Mensagem.ArqSalvaFimBD;
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaFimBD);

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

            this.lblBarraStatus.Text = Mensagem.ArqBuscaIniciadaPA;
            RegistroLog.RegistarLogInfo("-----------------" + Mensagem.ArqBuscaIniciadaPA + "-----------------");
            ArquivosPADataSUS arquivosPADataSUS = new ArquivosPADataSUS(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim(), this.txtDiretorioFTP_PA.Text.Trim(), this.txtDiretorioDestinoDownload.Text.Trim(), this.txtDestinoDBF.Text.Trim(), this.lblUF.Text.Trim());
            arquivosPADataSUS.BuscarArquivosFTP();
            this.lblBarraStatus.Text = Mensagem.ArqBuscaFinalizadaPA;
            RegistroLog.RegistarLogInfo(Mensagem.ArqBuscaFinalizadaPA);
            //
            this.lblBarraStatus.Text = Mensagem.ArqVerifNovos;
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifNovos);
            arquivosPADataSUS.BuscarArquivosBanco();
            arquivosPADataSUS.VerificarNovosArquivosFTP();
            //
            this.lblBarraStatus.Text = Mensagem.ArqVerifModificados;
            RegistroLog.RegistarLogInfo(Mensagem.ArqVerifModificados);
            arquivosPADataSUS.VerificarArquivosModificados();
            //
            this.lblBarraStatus.Text = Mensagem.DownloadInicio;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadInicio);
            arquivosPADataSUS.DownloadArquivos();
            this.lblBarraStatus.Text = Mensagem.DownloadFim;
            RegistroLog.RegistarLogInfo(Mensagem.DownloadFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqConversaoInicio;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoInicio);
            arquivosPADataSUS.ConverterArquivos();
            this.lblBarraStatus.Text = Mensagem.ArqConversaoFim;
            RegistroLog.RegistarLogInfo(Mensagem.ArqConversaoFim);
            //
            this.lblBarraStatus.Text = Mensagem.ArqSalvaInicioBD;
            RegistroLog.RegistarLogInfo(Mensagem.ArqSalvaInicioBD);
            arquivosPADataSUS.SalvarArquivoBanco();
            this.lblBarraStatus.Text = Mensagem.ArqSalvaFimBD;
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

        private void PreencherComboFrequencia()
        {

            IList<ListItemGenericoUtil> lista = new List<ListItemGenericoUtil>();

            lista.Add(new ListItemGenericoUtil(0, "Diariamente"));
            lista.Add(new ListItemGenericoUtil(1, "Domingos"));
            lista.Add(new ListItemGenericoUtil(2, "Segundas"));
            lista.Add(new ListItemGenericoUtil(3, "Terças"));
            lista.Add(new ListItemGenericoUtil(4, "Quartas"));
            lista.Add(new ListItemGenericoUtil(5, "Quintas"));
            lista.Add(new ListItemGenericoUtil(6, "Sextas"));
            lista.Add(new ListItemGenericoUtil(7, "Sabados"));

            this.ddlDiaAgendamento.DataSource = lista;
            this.ddlDiaAgendamento.DisplayMember = "Nome";
            this.ddlDiaAgendamento.ValueMember = "Id";
        }

        private bool Validar()
        {
            if (this.txtDiretorioDestinoDownload.Text.Trim().Length < 1)
            {
                MessageBox.Show(Mensagem.DiretorioInfoDestino);
                return false;
            }

            if (this.txtDestinoDBF.Text.Trim().Length < 1)
            {
                MessageBox.Show(Mensagem.DiretorioInfoDestino);
                return false;
            }

            return true;
        }

        private void CarregarConfiguracoes()
        {

            this.txtIPServidor.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppServidorFTP);
            this.txtDiretorioFTP_RD.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_RD);
            this.txtDiretorioFTP_RJ.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_RJ);
            this.txtDiretorioFTP_PA.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioFTP_Arq_PA);
            this.txtUsuario.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppUsuarioServidorOrigemFTP);
            this.txtSenha.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppSenhaUsuarioServidorOrigemFTP);
            this.txtDiretorioDestinoDownload.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioDestinoArquivosFTP);
            this.lblUF.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppUFArquivosDownload);
            this.ddlDiaAgendamento.SelectedValue = Convert.ToInt32(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppFrequenciaExecucao));
            this.nudHora.Value = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppHoraExecucao));
            this.nudMinuto.Value = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppMinutoExecucao));
            this.lblTipoArquivos.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppTiposArquivos);
            this.txtDestinoDBF.Text = AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppDiretorioDestinoArquivosDBF);
            int cadaMinuto = int.Parse(AppConfigUtil.ObterValorAppSettings(Constantes.ChaveAppExecucaoAcadaMinutos));

            if (cadaMinuto > 0)
            {
                this.nudCadaMinuto.Value = cadaMinuto;
                this.cbxAcadaMinuto.Checked = true;
            }
            else
                this.cbxAcadaMinuto.Checked = false;
        }

        private void DefinirAgendamentoExecucao()
        {
            RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoInicio);

            ISchedulerFactory schedFact = new StdSchedulerFactory();
            ITrigger trigger;

            this.scheduler = schedFact.GetScheduler();
            //this.scheduler.Start();

            IJobDetail job = JobBuilder.Create<FrmArquivoDataSUS>()
                .WithIdentity("JobAplicacao", "groupAplicacao")
                .Build();


            if (this.gbxAcadaMinuto.Enabled)
            {
                trigger = TriggerBuilder.Create()
                                      .StartNow()
                                      .WithSchedule(SimpleScheduleBuilder.RepeatMinutelyForever(Convert.ToInt32(this.nudCadaMinuto.Value.ToString())))
                                      .Build();
            }
            else
            {
                CronScheduleBuilder cronScheduleBuilder;

                Enumeradores.DiaDaSemana dia = Enumeradores.ConverterObject2DiaDaSemana(this.ddlDiaAgendamento.SelectedValue);

                if (dia == Enumeradores.DiaDaSemana.AllDays)
                    cronScheduleBuilder = CronScheduleBuilder.DailyAtHourAndMinute(Convert.ToInt32(this.nudHora.Value), Convert.ToInt32(this.nudMinuto.Value));
                else
                    cronScheduleBuilder = CronScheduleBuilder.WeeklyOnDayAndHourAndMinute((DayOfWeek)dia, Convert.ToInt32(this.nudHora.Value), Convert.ToInt32(this.nudMinuto.Value));

                trigger = TriggerBuilder.Create()
                                            .StartNow()
                                            .WithSchedule(cronScheduleBuilder)
                                            .Build();
            }

            this.scheduler.ScheduleJob(job, trigger);
            this.scheduler.Start();

            this.lblUltimaExecucao.Text = "--/--/---- --:--:--";
            this.lblProximaExecucao.Text = trigger.GetNextFireTimeUtc().Value.LocalDateTime.ToString(Constantes.FormatoDataHora);

            RegistroLog.RegistarLogInfo(Mensagem.SistemaAgendamentoFim);
        }

        public void Execute(IJobExecutionContext context)
        {
            if (formAtual.InvokeRequired)
            {
                FrmArquivoDataSUS.AtualizaFormExecucao callBack = new FrmArquivoDataSUS.AtualizaFormExecucao(FrmArquivoDataSUS.formAtual.ExecutarLocal);
                FrmArquivoDataSUS.formAtual.Invoke(callBack, context);
            }
            else
            {
                FrmArquivoDataSUS.formAtual.ExecutarLocal(context);
            }
        }

        public void ExecutarLocal(IJobExecutionContext context)
        {
            try
            {
                if (this.emExecucao)
                {
                    RegistroLog.RegistarLogInfo("**********************************************************************************");
                    RegistroLog.RegistarLogInfo(Mensagem.ServicoEmExecucao);
                    RegistroLog.RegistarLogInfo(Mensagem.SistemaUltimaExecucao + " (" + context.FireTimeUtc.Value.LocalDateTime.ToString(Constantes.FormatoDataHora) + ")");
                    RegistroLog.RegistarLogInfo(Mensagem.SistemaProximaExecucao + " (" + context.NextFireTimeUtc.Value.LocalDateTime.ToString(Constantes.FormatoDataHora) + ")");
                    RegistroLog.RegistarLogInfo("**********************************************************************************");
                }
                else
                {
                    //Inicia a o tratamento dos arquivos.
                    this.IniciarExecucao(context.FireTimeUtc.Value.LocalDateTime, context.NextFireTimeUtc.Value.LocalDateTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BaseAquivosDataSUS.SalvarLogErroAplicacao(ex);
            }
        }

        #endregion


    }
}
