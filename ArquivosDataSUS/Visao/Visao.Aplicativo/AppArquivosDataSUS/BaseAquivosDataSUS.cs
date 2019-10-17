using Application;
using Domain.Entity;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ArquivosDataSUS
{
    public abstract class BaseAquivosDataSUS
    {
        public BaseAquivosDataSUS(string servidorFTP, string usuarioFTP, string senhaFTP, string diretorioFTPArquivos, string diretorioDestinoDownload, string diretorioDestinoDBF, string estado, string tipoArquivo)
        {
            this.servidorFTP = servidorFTP;
            this.usuarioFTP = usuarioFTP;
            this.senhaFTP = senhaFTP;
            this.diretorioFTPArquivos = diretorioFTPArquivos;
            this.diretorioDestinoDownload = Path.Combine(diretorioDestinoDownload, tipoArquivo);
            this.diretorioDestinoDBF = Path.Combine(diretorioDestinoDBF, Constantes.TipoArquivoDBF, tipoArquivo);

            this.estadoUF = this.BuscarEstadoUFArquivo(estado);
            this.tipoArquivo = this.BuscarTipoArquivo(tipoArquivo);


            DirectorioUtil.CriarDiretorio(this.diretorioDestinoDownload);
            DirectorioUtil.CriarDiretorio(this.diretorioDestinoDBF);
        }

        #region Variáveis Locais

        private string servidorFTP;
        private string usuarioFTP;
        private string senhaFTP;
        private string diretorioFTPArquivos;
        private string diretorioDestinoDownload;
        private string diretorioDestinoDBF;
        private TipoArquivo tipoArquivo;
        private EstadoUF estadoUF;
        private List<string> listaArquivosFTP;
        private List<Arquivo> listaArquivosBanco;
        private List<string> listaArquivosNovosFTP;
        private List<Arquivo> listaArquivosSalvosBD;
        private List<Arquivo> listaArquivosModificados;
        private List<string> listaArquivosFalhaDownload;
        private List<Arquivo> listaArquivosFalhaConversaoDBF;
        private List<Arquivo> listaArquivosFalhaModificados;



        #endregion

        #region Propriedades
        public List<Arquivo> ListaArquivosFalhaModificados
        {
            get { return listaArquivosFalhaModificados; }
            //set { listaArquivosFalhaModificados = value; }
        }
        public List<Arquivo> ListaArquivosFalhaConversaoDBF
        {
            get { return listaArquivosFalhaConversaoDBF; }
            // set { listaArquivosFalhaConversaoDBF = value; }
        }

        public List<string> ListaArquivosFalhaDownload
        {
            get { return listaArquivosFalhaDownload; }
            //set { listaArquivosFalhaDownload = value; }
        }

        public List<Arquivo> ListaArquivosModificados
        {
            get { return listaArquivosModificados; }
            //set { listaArquivosModificados = value; }
        }

        public TipoArquivo TipoArquivo
        {
            get { return tipoArquivo; }
            //set { tipoArquivo = value; }
        }

        public List<Arquivo> ListaArquivosSalvosBD
        {
            get { return listaArquivosSalvosBD; }
            set { listaArquivosSalvosBD = value; }
        }

        public List<string> ListaArquivosNovosFTP
        {
            get { return listaArquivosNovosFTP; }
            set { listaArquivosNovosFTP = value; }
        }

        public List<string> ListaArquivosFTP
        {
            get { return listaArquivosFTP; }
            set { listaArquivosFTP = value; }
        }

        public List<Arquivo> ListaArquivosBanco
        {
            get { return listaArquivosBanco; }
            //   set { listaArquivosBanco = value; }
        }

        public string DiretorioDestinoDBF
        {
            get { return diretorioDestinoDBF; }
            // set { diretorioDestinoDBF = value; }
        }

        public EstadoUF EstadoUF
        {
            get
            {
                this.estadoUF = this.estadoUF ?? new EstadoUF();
                return estadoUF;
            }
            set { estadoUF = value; }
        }

        public string DiretorioDestinoDownload
        {
            get { return diretorioDestinoDownload; }
            // set { diretorioDestinoDownload = value; }
        }

        public string DiretorioFTPArquivos
        {
            get { return diretorioFTPArquivos; }
            // set { diretorioFTPArquivos = value; }
        }

        public string SenhaFTP
        {
            get { return senhaFTP; }
            //set { senhaFTP = value; }
        }

        public string UsuarioFTP
        {
            get { return usuarioFTP; }
            //set { usuarioFTP = value; }
        }

        public string ServidorFTP
        {
            get { return servidorFTP; }
            //set { servidorFTP = value; }
        }

        #endregion

        #region Métodos Abstratos

        public abstract string TratarNomeArquivo(string retornoFTP);
        public abstract string TratarUFArquivo(string retornoFTP);
        public abstract string TratarTipoArquivo(string retornoFTP);
        public abstract int TratarDataDadosArquivo(string retornoFTP);

        //public abstract int TratarTamanhoArquivo(string retornoFTP);
        public abstract void BuscarArquivosFTP();

        #endregion

        #region Métodos Privados

        private void SalvarLogAquivoBanco(LogArquivo arquivo)
        {
            LogArquivoApplication arqApp = new LogArquivoApplication();
            arqApp.AlteraOuInsere(arquivo);
        }

        private long BuscarTamanhoArquivoFTP(string nomeArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);
            return ftp.ObterTamanhoArquivo(this.diretorioFTPArquivos, nomeArquivo);
        }

        private DateTime BuscarDataModificacaoArquivoFTP(string nomeArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);
            return ftp.ObterDataModificacaoArquivo(this.diretorioFTPArquivos, nomeArquivo);
        }

        private void DownloadArquivosFTP(string nomeArquivo)
        {

            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);
            ftp.Download(this.diretorioFTPArquivos, nomeArquivo, this.diretorioDestinoDownload);
        }


        private bool VerificarConversaoArquivo(string pathDestino, string arquivo)
        {
            string arquivoDBF = arquivo.Replace(Constantes.ExtensaoArquivosDBC, Constantes.ExtensaoArquivosDBF).ToUpper();

            return DirectorioUtil.VerificarArquivoExiste(pathDestino, arquivoDBF);
        }

        private bool ConverterArquivoDBCtoBDF(Arquivo arquivo, string pathDestinoDBF)
        {
            int saidaExecucao = -1;
            string arquivoDBC = Path.Combine(arquivo.LocalDestino, arquivo.Nome);

            try
            {
                if (arquivoDBC.Contains(Constantes.ExtensaoArquivosDBC))
                {
                    string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                    string parametros = arquivoDBC + " " + pathDestinoDBF + "\\";
                    System.Diagnostics.Process resutado;

                    resutado = System.Diagnostics.Process.Start(Path.Combine(path, Constantes.ProgramaConversaoDBF2DBC), parametros);
                    resutado.WaitForExit(Constantes.TempoEsperaConversao);

                    if (resutado.HasExited)
                        saidaExecucao = resutado.ExitCode;
                }
            }
            catch (Exception ex)
            {
                this.listaArquivosFalhaConversaoDBF.Add(arquivo);
                this.RegistarLogErroArquivo(arquivo, Mensagem.ArqFalhaConversao + " - " + ex.Message);
            }

            return saidaExecucao == 0;
        }

        private Arquivo AtualizarInfObjArquivo(Arquivo arquivo)
        {
            arquivo.DataDownload = DateTime.Now;
            arquivo.Tamanho = (int)this.BuscarTamanhoArquivoFTP(arquivo.Nome);
            arquivo.TotalDownloads += 1;
            arquivo.SucessoDownload = true;
            arquivo.SucessoConversao = true;
            arquivo.DataAlteracaoRegistro = DateTime.Now;

            return arquivo;
        }

        private Arquivo CriarNovoObjArquivo(string arquivoFTP)
        {
            Arquivo arquivo = new Arquivo();

            // TODO: Solução temporária. Pesquisar forma melhor de obter datas e tamanho do arquivo FTP.

            arquivo.Nome = this.TratarNomeArquivo(arquivoFTP);
            arquivo.DataCriacao = this.BuscarDataModificacaoArquivoFTP(arquivo.Nome);
            arquivo.DataModificacao = arquivo.DataCriacao;
            arquivo.DataDados = this.TratarDataDadosArquivo(arquivoFTP);
            arquivo.DataDownload = DateTime.Now;
            arquivo.Tamanho = this.BuscarTamanhoArquivoFTP(arquivoFTP);
            arquivo.TotalDownloads = 1;
            arquivo.IdEstadoUF = this.estadoUF.Id;
            arquivo.IdTipoArquivo = this.tipoArquivo.Id;
            arquivo.LocalDestino = this.diretorioDestinoDownload;
            arquivo.LocalDestinoDBF = this.diretorioDestinoDBF;
            arquivo.SucessoDownload = true;
            arquivo.SucessoConversao = true;

            if (this.diretorioFTPArquivos.Length > 0)
                arquivo.LocalOrigem = Path.Combine(this.servidorFTP, this.diretorioFTPArquivos);
            else
                arquivo.LocalOrigem = this.servidorFTP;

            return arquivo;
        }

        private void SalvarLogErroArquivo(LogErroArquivo log)
        {
            LogErroArquivoApplication logApp = new LogErroArquivoApplication();
            logApp.Insere(log);
        }

        private void ConverterArquivosNovos()
        {
            foreach (var item in this.listaArquivosNovosFTP)
            {
                if (!this.listaArquivosFalhaDownload.Contains(item))
                {
                    this.ConverterArquivo(this.CriarNovoObjArquivo(item));
                }
            }
        }

        private void ConverterArquivosModificados()
        {
            foreach (Arquivo item in this.listaArquivosModificados)
            {
                Arquivo arquivo = this.AtualizarInfObjArquivo(item);

                if (this.listaArquivosFalhaDownload.Contains(item.Nome))
                {
                    arquivo.SucessoDownload = false;
                }

                this.ConverterArquivo(arquivo);
            }
        }

        private void ConverterArquivo(Arquivo arquivo)
        {
            if (!this.ConverterArquivoDBCtoBDF(arquivo, arquivo.LocalDestinoDBF))
            {
                ArquivoUtil.ExcluirArquivo(arquivo.LocalDestinoDBF, arquivo.Nome);
                arquivo.SucessoConversao = false;
            }
            else
            {
                if (!this.VerificarConversaoArquivo(arquivo.LocalDestinoDBF, arquivo.Nome))
                {
                    arquivo.SucessoConversao = false;
                    this.listaArquivosFalhaConversaoDBF.Add(arquivo);
                    this.RegistarLogErroArquivo(arquivo, Mensagem.ArqFalhaConversao);
                }
            }

            this.listaArquivosSalvosBD.Add(arquivo);
        }


        private void RegistrarLogArquivo(Arquivo arquivo)
        {
            LogArquivo logArquivo = new LogArquivo();

            logArquivo.Nome = arquivo.Nome;
            logArquivo.DataModificacao = arquivo.DataModificacao;
            logArquivo.DataCriacao = arquivo.DataCriacao;
            logArquivo.DataDownload = arquivo.DataDownload;
            logArquivo.LocalDestino = arquivo.LocalDestino;
            logArquivo.LocalDestinoDBF = arquivo.LocalDestinoDBF;
            logArquivo.LocalOrigem = arquivo.LocalOrigem;
            logArquivo.SucessoConversao = arquivo.SucessoConversao;
            logArquivo.SucessoDownload = arquivo.SucessoDownload;
            logArquivo.Tamanho = arquivo.Tamanho;

            if (arquivo.DataAlteracaoRegistro.HasValue)
            {
                logArquivo.DataAlteracaoRegistro = arquivo.DataAlteracaoRegistro;
                logArquivo.EventoInclusao = false;
            }
            else
            {
                logArquivo.EventoInclusao = true;
                logArquivo.DataAlteracaoRegistro = DateTime.Now;
            }

            this.SalvarLogAquivoBanco(logArquivo);

        }

        private void RegistarLogErroArquivo(string arquivo, string erro)
        {
            LogErroArquivo log = new LogErroArquivo();
            log.NomeArquivo = arquivo;
            log.DataAlteracaoRegistro = DateTime.Now;
            log.DataErro = DateTime.Now;

            this.SalvarLogErroArquivo(log);
        }

        public void RegistarLogErroArquivo(Arquivo arquivo, string erro)
        {
            LogErroArquivo log = new LogErroArquivo();

            log.DataAlteracaoRegistro = DateTime.Now;
            log.DataErro = DateTime.Now;
            log.LocalDestino = arquivo.LocalDestino;
            log.LocalDestinoDBF = arquivo.LocalDestinoDBF;
            log.MsgErro = erro;
            log.NomeArquivo = arquivo.Nome;
            log.TamanhoArquivo = arquivo.Tamanho;

            this.SalvarLogErroArquivo(log);
        }

        #endregion

        #region Métodos Virtuais

        public virtual TipoArquivo BuscarTipoArquivo(string tipoArquivo)
        {
            TipoArquivoApplication tipoApp = new TipoArquivoApplication();

            return tipoApp.repositorioTipoArquivo.FindByName(tipoArquivo); ;
        }

        public virtual EstadoUF BuscarEstadoUFArquivo(string uf)
        {
            EstadoUFApplication ufApp = new EstadoUFApplication();

            return ufApp.repositorioEstadoUF.FindByUF(uf);
        }

        public virtual Arquivo BuscarArquivoBanco(string arquivoNome)
        {
            ArquivoApplication arquivoApp = new ArquivoApplication();

            return arquivoApp.repositorioArquivo.GetByName(arquivoNome);
        }

        public virtual List<Arquivo> BuscarArqEstadoTipoBanco(string estadoUF, string tipoArquivo)
        {
            ArquivoApplication arquivoApp = new ArquivoApplication();
            List<Arquivo> arquivosBanco = new List<Arquivo>();

            arquivosBanco = arquivoApp.repositorioArquivo.GetByUFeTipoArquivo(estadoUF, tipoArquivo);

            return arquivosBanco;

        }

        public virtual List<string> ListarNomesArquivosFTP()
        {
            List<string> listaArquivos = new List<string>();

            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);

            listaArquivos = ftp.ListarDiretorioSimples(this.diretorioFTPArquivos).ToList<string>();

            return listaArquivos;

        }

        public virtual List<string> ListarDetalhesArquivosFTP()
        {
            List<string> listaArquivos = new List<string>();

            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);

            listaArquivos = ftp.ListarDiretorioDetalhado(this.diretorioFTPArquivos).ToList<string>();

            return listaArquivos;

        }

        public virtual void BuscarArquivosBanco()
        {
            this.listaArquivosBanco = this.BuscarArqEstadoTipoBanco(this.estadoUF.Sigla, this.tipoArquivo.Nome);
        }

        public virtual void VerificarNovosArquivosFTP()
        {
            this.listaArquivosNovosFTP = new List<string>();

            if (this.listaArquivosBanco.Count == 0)
            {
                this.listaArquivosNovosFTP.AddRange(this.listaArquivosFTP);
            }
            else
            {
                foreach (string item in this.listaArquivosFTP)
                {
                    if (!this.listaArquivosBanco.Exists(x => x.Nome.Contains(this.TratarNomeArquivo(item))))
                        this.listaArquivosNovosFTP.Add(item);
                }
            }
        }

        public virtual void VerificarArquivosModificados()
        {
            this.listaArquivosModificados = new List<Arquivo>();
            this.listaArquivosFalhaModificados = new List<Arquivo>();

            DateTime dataModificaoArquivoRemoto;

            foreach (Arquivo item in this.listaArquivosBanco)
            {
                try
                {
                    dataModificaoArquivoRemoto = this.BuscarDataModificacaoArquivoFTP(item.Nome);

                    if (!item.DataModificacao.Equals(dataModificaoArquivoRemoto))
                    {
                        item.DataModificacao = dataModificaoArquivoRemoto;
                        this.listaArquivosModificados.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    this.listaArquivosFalhaModificados.Add(item);
                    this.RegistarLogErroArquivo(item.Nome, Mensagem.ArqNaoEncontrado + " - " + ex.Message);
                }
            }

        }

        public virtual void DownloadArquivos()
        {
            string pathArquivoCompleto = string.Empty;
            string nomeArquivo = string.Empty;

            this.listaArquivosFalhaDownload = new List<string>();

            foreach (string item in this.listaArquivosNovosFTP)
            {
                try
                {
                    nomeArquivo = this.TratarNomeArquivo(item);
                    pathArquivoCompleto = Path.Combine(this.diretorioDestinoDownload, nomeArquivo);
                    this.DownloadArquivosFTP(nomeArquivo);
                }
                catch (Exception ex)
                {
                    this.listaArquivosFalhaDownload.Add(nomeArquivo);
                    this.RegistarLogErroArquivo(nomeArquivo, Mensagem.DownloadFalha + " - " + ex.Message);

                }
            }

            foreach (Arquivo item in this.listaArquivosModificados)
            {
                try
                {
                    this.DownloadArquivosFTP(item.Nome);
                }
                catch (Exception ex)
                {
                    this.listaArquivosFalhaDownload.Add(item.Nome);
                    this.RegistarLogErroArquivo(item, Mensagem.DownloadFalha + " - " + ex.Message);
                }
            }
        }


        public virtual void ConverterArquivos()
        {
            this.listaArquivosFalhaConversaoDBF = new List<Arquivo>();
            this.listaArquivosSalvosBD = new List<Arquivo>();
            //
            this.ConverterArquivosNovos();
            this.ConverterArquivosModificados();
        }

        public virtual void SalvarArquivoBanco()
        {
            ArquivoApplication arqApp = new ArquivoApplication();

            foreach (Arquivo item in this.listaArquivosSalvosBD)
            {
                arqApp.AlteraOuInsere(item);
                this.RegistrarLogArquivo(item);
            }

        }


        #endregion

        #region Métodos Estáticos

        public static void SalvarLogErroAplicacao(Exception excecao)
        {
            SalvarLogErroAplicacao(string.Empty, excecao);
        }
        public static void SalvarLogErroAplicacao(string mensagem, Exception excecao)
        {
            SalvarLogErroAplicacao(string.Empty, mensagem, excecao);
        }
        public static void SalvarLogErroAplicacao(string nomeObjeto, string mensagem, Exception excecao)
        {
            try
            {
                LogErroAplicacaoApplication logApp = new LogErroAplicacaoApplication();
                LogErroAplicacao log = new LogErroAplicacao();

                if (excecao.InnerException != null)
                {
                    if (excecao.InnerException.InnerException != null)
                        if (excecao.InnerException.InnerException.InnerException != null)
                            log.Excecao = excecao.InnerException.InnerException.InnerException.Message;
                        else
                            log.Excecao = excecao.InnerException.InnerException.Message;
                    else
                        log.Excecao = excecao.InnerException.Message;
                }

                log.Data = DateTime.Now;
                log.Mensagem = excecao.Message;

                if (!nomeObjeto.Equals(string.Empty))
                    //log.NomeObjeto = nomeObjeto;

                if (!mensagem.Equals(string.Empty))
                    log.Mensagem = mensagem + " - " + excecao.Message;

                log.Origem = excecao.Source;
                log.CodExcecao = excecao.HResult;

                logApp.Insere(log);

                RegistroLog.RegistarLogErro(Mensagem.ErroSistema + " | " + mensagem + " ( " + excecao.Message + " )", excecao);
            }
            catch (Exception ex)
            {
                GravarAquivoErro(Mensagem.ErroSalvarBD + " | " + mensagem + "( " + ex.Message + " )", ex);
            }

        }


        public static void GravarAquivoErro(string mensagemErro, Exception excecao)
        {
            try
            {
                RegistroLog.RegistarLogErro(mensagemErro, excecao);
            }
            catch (Exception ex)
            {
                throw new Exception(Mensagem.ErroFatalSistema + "( " + ex.Message + " )", ex);
            }
        }

        #endregion

    }
}
