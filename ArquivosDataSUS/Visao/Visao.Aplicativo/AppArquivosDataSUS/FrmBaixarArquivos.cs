using Infrastructure.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Windows.Forms;

namespace ArquivosDataSUS
{
    public partial class FrmBaixarArquivos : Form
    {
        public FrmBaixarArquivos()
        {
            InitializeComponent();
        }

        #region Eventos

        private void FrmListaBaixarArquivos_Load(object sender, EventArgs e)
        {
        }

        private void btnFTPSalvar_Click(object sender, EventArgs e)
        {

            this.txtIPServidor.Text.Trim();
            this.txtUsuario.Text.Trim();
            this.txtSenha.Text.Trim();

            this.btnFTPSalvar.Enabled = false;
        }

        private void btnListaArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                IList<string> nomeArquivos = this.GetListaArquivos();


                this.lbArquivos.Items.Clear();

                if (nomeArquivos == null)
                {
                    this.lbArquivos.Items.Add(Mensagem.ArqNaoEncontrado);
                }
                else
                {
                    foreach (string _nomeArquivo in nomeArquivos)
                    {
                        this.lbArquivos.Items.Add(_nomeArquivo);
                    }

                    this.btnDownloadSelecao.Enabled = true;

                    MessageBox.Show(Mensagem.ArqListagemFim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnListaDetalhesArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnDownloadSelecao.Enabled = false;

                IList<string> nomeArquivos = this.GetListaDetalhesArquivos();

                this.lbArquivos.Items.Clear();

                if (nomeArquivos == null)
                {
                    this.lbArquivos.Items.Add(Mensagem.ArqNaoEncontrado);
                }
                else
                {
                    foreach (string _nomeArquivo in nomeArquivos)
                    {
                        this.lbArquivos.Items.Add(_nomeArquivo);
                    }

                    MessageBox.Show(Mensagem.ArqListagemFim);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEscolherDiretorioSelecao_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fldDlg = new FolderBrowserDialog();

            if (fldDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtDiretorioDestinoDownload.Text = fldDlg.SelectedPath;
            }
        }


        private void btnDownloadSelecao_Click(object sender, EventArgs e)
        {
            this.progressBar.Maximum = this.lbArquivos.SelectedItems.Count;

            if (this.txtDiretorioDestinoDownload.Text.Trim().Length > 0)
            {
                try
                {
                    foreach (string item in this.lbArquivos.SelectedItems)
                    {
                        this.DownloadArquivos(item, this.txtDiretorioDestinoDownload.Text.Trim());
                        this.progressBar.Value += 1;
                    }

                    MessageBox.Show(Mensagem.DownloadFim);

                    this.progressBar.Maximum = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show(Mensagem.DiretorioInfoDestino);
            }

        }
   
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        #endregion

        #region Métodos

        public IList<string> GetListaArquivos()
        {
            IList<string> listaArquivos = new List<string>();

            try
            {
                FTPSimple ftp = new FTPSimple(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim());

                listaArquivos = ftp.ListarDiretorioSimples(this.txtDiretorioFTP.Text.Trim()).ToList<string>();

                return listaArquivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<string> GetListaDetalhesArquivos()
        {
            IList<string> listaArquivos = new List<string>();

            try
            {
                FTPSimple ftp = new FTPSimple(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim());

                listaArquivos = ftp.ListarDiretorioDetalhado(this.txtDiretorioFTP.Text.Trim()).ToList<string>();

                return listaArquivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void DownloadArquivos(string nomeArquivo, string pathDestinoArquivo)
        {
            FTPSimple ftp = new FTPSimple(this.txtIPServidor.Text.Trim(), this.txtUsuario.Text.Trim(), this.txtSenha.Text.Trim());

            ftp.Download(this.txtDiretorioFTP.Text.Trim(), nomeArquivo, pathDestinoArquivo);
        }

        #endregion

   
    }
}
