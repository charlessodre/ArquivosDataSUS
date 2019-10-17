using Application;
using Domain.Entity;
using Infrastructure.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquivosDataSUS
{
    public class BaseFormDataSUS : Form
    {
       

        #region Variáveis Locais

        private string servidorFTP;
        private string usuarioFTP;
        private string senhaFTP;
        private string diretorioFTPArquivos;
        private string diretorioDestinoDownload;
        private string diretorioDestinoDBF;
        private EstadoUF estadoUF;
        private List<string> listaArquivosFTP;
        private List<Arquivo> listaArquivosBanco;
        private List<string> listaArquivosNovosFTP;
        private List<Arquivo> listaArquivosSalvosBD;

        public List<Arquivo> ListaArquivosSalvosBD
        {
            get { return listaArquivosSalvosBD; }
            set { listaArquivosSalvosBD = value; }
        }

        #endregion

        #region Propriedades

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
            set { listaArquivosBanco = value; }
        }

        public string DiretorioDestinoDBF
        {
            get { return diretorioDestinoDBF; }
            set { diretorioDestinoDBF = value; }
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
            set { diretorioDestinoDownload = value; }
        }

        public string DiretorioFTP
        {
            get { return diretorioFTPArquivos; }
            set { diretorioFTPArquivos = value; }
        }

        public string SenhaFTP
        {
            get { return senhaFTP; }
            set { senhaFTP = value; }
        }

        public string UsuarioFTP
        {
            get { return usuarioFTP; }
            set { usuarioFTP = value; }
        }

        public string ServidorFTP
        {
            get { return servidorFTP; }
            set { servidorFTP = value; }
        }

        #endregion


        public long BuscarTamanhoArquivoFTP(string nomeArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);
            return ftp.ObterTamanhoArquivo(this.diretorioFTPArquivos, nomeArquivo);
        }

        public void DownloadArquivosFTP(string nomeArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);

            ftp.Download(this.diretorioFTPArquivos, nomeArquivo, this.diretorioDestinoDownload);

        }

        public string TratarNomeArquivo(string retornoFTP)
        {
            return retornoFTP.Substring(39, 12);
        }

        public string TratarUFArquivo(string retornoFTP)
        {
            return this.TratarNomeArquivo(retornoFTP).Substring(2, 2);
        }

        public string TratarTipoArquivo(string retornoFTP)
        {
            return this.TratarNomeArquivo(retornoFTP).Substring(0, 2).ToUpper();
        }

        public int TratarDataDadosArquivo(string retornoFTP)
        {
            return Convert.ToInt32(retornoFTP.Substring(43, 4));
        }

        public int TratarTamanhoArquivo(string retornoFTP)
        {
            return Convert.ToInt32(retornoFTP.Substring(23, 15)); ;
        }

        public TipoArquivo BuscarTipoArquivo(string tipoArquivo)
        {
            TipoArquivoApplication tipoApp = new TipoArquivoApplication();

            return tipoApp.repositorioTipoArquivo.FindByName(tipoArquivo); ;
        }

        public EstadoUF BuscarEstadoUFArquivo(string uf)
        {
            EstadoUFApplication ufApp = new EstadoUFApplication();

            return ufApp.repositorioEstadoUF.FindByUF(uf);
        }

        public Arquivo BuscarArquivoBanco(Arquivo arquivo)
        {
            ArquivoApplication arquivoApp = new ArquivoApplication();

            return arquivoApp.repositorioArquivo.GetByName(arquivo.Nome);
        }

        public void BuscarArquivosRD(string diretorioFTPArquivos)
        {
            this.diretorioFTPArquivos = diretorioFTPArquivos;

            //Lista todos os arquivos do diretório FTP.
            this.listaArquivosFTP = this.ListarDetalhesArquivosFTP();

            //Mantenho somente os arquivos do tipo RD.
            this.listaArquivosFTP = this.listaArquivosFTP.Where(x => this.TratarTipoArquivo(x).Equals(Constantes.TipoArquivoRD)).ToList();

            //Mantenho somente os arquivos do estado selecionado.
            this.listaArquivosFTP = this.ListaArquivosFTP.Where(x => this.TratarUFArquivo(x).Equals(this.estadoUF.Sigla)).ToList();
        }

        public void BuscarArquivosRJ(string diretorioFTPArquivos)
        {
            this.diretorioFTPArquivos = diretorioFTPArquivos;

            //Lista todos os arquivos do diretório FTP.
            this.listaArquivosFTP = this.ListarDetalhesArquivosFTP();

            //Mantenho somente os arquivos do tipo RJ.
            this.listaArquivosFTP = this.listaArquivosFTP.Where(x => this.TratarTipoArquivo(x).Equals(Constantes.TipoArquivoRJ)).ToList();

            //Mantenho somente os arquivos do estado selecionado.
            this.listaArquivosFTP = this.ListaArquivosFTP.Where(x => this.TratarUFArquivo(x).Equals(this.estadoUF.Sigla)).ToList();
        }

        public void BuscarArquivosPA(string diretorioFTPArquivos)
        {
            this.diretorioFTPArquivos = diretorioFTPArquivos;

            //Lista todos os arquivos do diretório FTP.
            this.listaArquivosFTP = this.ListarDetalhesArquivosFTP();

            //Mantenho somente os arquivos do tipo PA.
            this.listaArquivosFTP = this.listaArquivosFTP.Where(x => this.TratarTipoArquivo(x).Equals(Constantes.TipoArquivoPA)).ToList();

            //Mantenho somente os arquivos do estado selecionado.
            this.listaArquivosFTP = this.ListaArquivosFTP.Where(x => this.TratarUFArquivo(x).Equals(this.estadoUF.Sigla)).ToList();
        }

        private List<string> ListarDetalhesArquivosFTP()
        {
            List<string> listaArquivos = new List<string>();

            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);

            listaArquivos = ftp.ListarDiretorioDetalhado(this.diretorioFTPArquivos).ToList<string>();

            return listaArquivos;

        }

        public List<Arquivo> BuscarArqEstadoTipoBanco(string estadoUF, string tipoArquivo)
        {
            ArquivoApplication arquivoApp = new ArquivoApplication();
            List<Arquivo> arquivosBanco = new List<Arquivo>();

            arquivosBanco = arquivoApp.repositorioArquivo.GetByUFeTipoArquivo(estadoUF, tipoArquivo);

            return arquivosBanco;

        }

        public void VerificarNovosArquivosFTP()
        {
            this.ListaArquivosNovosFTP = new List<string>();

            if (this.listaArquivosBanco.Count == 0)
            {
                this.ListaArquivosNovosFTP.AddRange(this.listaArquivosFTP);
            }
            else
            {
                foreach (string item in this.listaArquivosFTP)
                {
                    if (!this.ListaArquivosBanco.Exists(x => x.Nome.Contains(this.TratarNomeArquivo(item))))
                        this.ListaArquivosNovosFTP.Add(item);
                }
            }
        }

        public void VerificarArquivosModificados()
        {
            DateTime dataModificaoArquivoRemoto;

            foreach (Arquivo item in this.listaArquivosBanco)
            {
                dataModificaoArquivoRemoto = this.BuscarDataModificacaoArquivoFTP(item.Nome);

                if (!item.DataModificacao.Equals(dataModificaoArquivoRemoto))
                {
                    this.listaArquivosNovosFTP.Add(item.Nome);
                }
            }

        }

        private DateTime BuscarDataModificacaoArquivoFTP(string nomeArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.servidorFTP, this.usuarioFTP, this.senhaFTP);
            return ftp.ObterDataModificacaoArquivo(this.diretorioFTPArquivos, nomeArquivo);
        }

        public void DownloadArquivos()
        {
            string pathArquivoCompleto = string.Empty;
            string nomeArquivo = string.Empty;

            this.listaArquivosSalvosBD = new List<Arquivo>();

            foreach (string item in this.listaArquivosNovosFTP)
            {
                nomeArquivo = this.TratarNomeArquivo(item);
                pathArquivoCompleto = this.diretorioDestinoDownload + "\\" + nomeArquivo;
                //
                this.DownloadArquivosFTP(nomeArquivo);
                //
                //this.listaArquivosBaixados.Add(this.CriarNovoObjArquivo(item));

            }

        }

        private Arquivo CriarNovoObjArquivo(string arquivoFTP, int idTipoArquivo)
        {
            Arquivo arquivo = new Arquivo();

            // TODO: Solução temporária. Pesquisar forma melhor de obter datas do arquivo FTP.

            arquivo.Nome = this.TratarNomeArquivo(arquivoFTP);
            arquivo.DataCriacao = this.BuscarDataModificacaoArquivoFTP(arquivo.Nome);
            arquivo.DataModificacao = arquivo.DataCriacao;
            arquivo.DataDados = this.TratarDataDadosArquivo(arquivoFTP);
            arquivo.DataDownload = DateTime.Now;
            arquivo.Tamanho = this.TratarTamanhoArquivo(arquivoFTP);
            arquivo.TotalDownloads += 1;
            arquivo.IdEstadoUF = this.estadoUF.Id;
            arquivo.IdTipoArquivo = idTipoArquivo;
            arquivo.LocalDestino = this.diretorioDestinoDownload;
            arquivo.LocalDestinoDBF = this.diretorioDestinoDBF;
            arquivo.DataAlteracaoRegistro = DateTime.Now;

            if (this.diretorioFTPArquivos.Length > 0)
                arquivo.LocalOrigem = this.servidorFTP + "//" + this.diretorioFTPArquivos;
            else
                arquivo.LocalOrigem = this.servidorFTP;

            return arquivo;
        }

        public void SalvarArquivoBanco(TipoArquivo tipoArquivo)
        {
            ArquivoApplication arqApp = new ArquivoApplication();
            this.listaArquivosSalvosBD = new List<Arquivo>();

            foreach (var item in this.listaArquivosNovosFTP)
            {
                Arquivo arquivo = this.CriarNovoObjArquivo(item, tipoArquivo.Id);
                arqApp.AlteraOuInsere(arquivo);
                this.listaArquivosSalvosBD.Add(arquivo);
            }
        }

        public void ConverterArquivos()
        {
            foreach (Arquivo item in this.listaArquivosSalvosBD)
            {
                this.ConverterArquivoDBCtoBDF(item.LocalDestino + "\\" + item.Nome, item.LocalDestinoDBF);
                    if (!this.VerificarConversaoArquivo(item.LocalDestinoDBF, item.Nome.ToUpper().Replace(Constantes.ExtensaoArquivosDBC, Constantes.ExtensaoArquivosDBF)))
                        this.SalvarLogErroArquivo(item, Mensagem.ArqFalhaConversao);
            }
        }

        public void SalvarLogErroAplicacao(Exception excecao)
        {
            try
            {
                LogErroAplicacaoApplication logApp = new LogErroAplicacaoApplication();
                LogErroAplicacao log = new LogErroAplicacao();

                if (excecao.InnerException != null)
                    log.Excecao = excecao.InnerException.Message;

                log.Data = DateTime.Now;
                log.Mensagem = excecao.Message;
                log.Origem = excecao.Source;
                log.CodExcecao = excecao.HResult;

                logApp.Insere(log);
            }
            catch (Exception ex)
            {
                this.GravarAquivoErro(Mensagem.ErroSalvarBD, ex);
            }
        }

        public bool VerificarConversaoArquivo(string pathDestino, string arquivo)
        {
            bool existe = DirectoryInfoUtil.VerificarArquivoExiste(pathDestino, arquivo);

            return existe;
        }

        public bool ConverterArquivoDBCtoBDF(string arquivoDBC, string pathDestinoDBF)
        {
            int saidaExecucao = -1;

            if (arquivoDBC.Contains(Constantes.ExtensaoArquivosDBC))
            {

                System.Diagnostics.Process resutado;

                string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string path2 = path.Remove(path.LastIndexOf(Constantes.DiretorioRaizUI));
                string parametros = arquivoDBC + " " + pathDestinoDBF + "\\";

                resutado = System.Diagnostics.Process.Start(path2 + Constantes.ProgramaConversaoDBF2DBC, parametros);
                resutado.WaitForExit(Constantes.TempoEsperaConversao);

                if (resutado.HasExited)
                    saidaExecucao = resutado.ExitCode;
            }

            return saidaExecucao == 0;
        }

        public void SalvarLogErroArquivo(Arquivo arquivo, string erro)
        {
            LogErroArquivoApplication logApp = new LogErroArquivoApplication();

            LogErroArquivo log = new LogErroArquivo();

            log.DataAlteracaoRegistro = DateTime.Now;
            log.DataErro = DateTime.Now;
            log.LocalDestino = arquivo.LocalDestino;
            log.LocalDestinoDBF = arquivo.LocalDestinoDBF;
            log.MsgErro = erro;
            log.NomeArquivo = arquivo.Nome;
            log.TamanhoArquivo = arquivo.Tamanho;

            logApp.Insere(log);

        }

        public void GravarAquivoErro(string mensagemErro, Exception excecao)
        {
            try
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.ErrorException(mensagemErro, excecao);

            }
            catch (Exception ex)
            {

                MessageBox.Show(Mensagem.ErroFatalSistema + " \n " + ex.Message);
            }
        }
    }
}
