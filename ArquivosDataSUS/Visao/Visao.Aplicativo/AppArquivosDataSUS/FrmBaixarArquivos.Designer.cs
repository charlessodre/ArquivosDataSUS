namespace ArquivosDataSUS
{
    partial class FrmBaixarArquivos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaixarArquivos));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtDiretorioFTP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPServidor = new System.Windows.Forms.TextBox();
            this.btnFTPSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcConfiguracao = new System.Windows.Forms.TabControl();
            this.tabListarArquivos = new System.Windows.Forms.TabPage();
            this.btnFechar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnDownloadSelecao = new System.Windows.Forms.Button();
            this.btnEscolherDiretorioDownload = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiretorioDestinoDownload = new System.Windows.Forms.TextBox();
            this.lbArquivos = new System.Windows.Forms.ListBox();
            this.btnListaDetalhesArquivos = new System.Windows.Forms.Button();
            this.btnListaArquivos = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.tbcConfiguracao.SuspendLayout();
            this.tabListarArquivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.txtDiretorioFTP);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.txtSenha);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtUsuario);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtIPServidor);
            this.groupBox7.Controls.Add(this.btnFTPSalvar);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(13, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(550, 126);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Configurações FTP";
            // 
            // txtDiretorioFTP
            // 
            this.txtDiretorioFTP.Location = new System.Drawing.Point(6, 69);
            this.txtDiretorioFTP.Name = "txtDiretorioFTP";
            this.txtDiretorioFTP.Size = new System.Drawing.Size(538, 20);
            this.txtDiretorioFTP.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Dirertório do FTP";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(381, 28);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(163, 20);
            this.txtSenha.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(193, 28);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(163, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuário";
            // 
            // txtIPServidor
            // 
            this.txtIPServidor.Location = new System.Drawing.Point(5, 28);
            this.txtIPServidor.Name = "txtIPServidor";
            this.txtIPServidor.Size = new System.Drawing.Size(163, 20);
            this.txtIPServidor.TabIndex = 1;
            this.txtIPServidor.Text = "ftp.datasus.gov.br";
            // 
            // btnFTPSalvar
            // 
            this.btnFTPSalvar.Location = new System.Drawing.Point(5, 96);
            this.btnFTPSalvar.Name = "btnFTPSalvar";
            this.btnFTPSalvar.Size = new System.Drawing.Size(539, 23);
            this.btnFTPSalvar.TabIndex = 5;
            this.btnFTPSalvar.Text = "Aplicar";
            this.btnFTPSalvar.UseVisualStyleBackColor = true;
            this.btnFTPSalvar.Click += new System.EventHandler(this.btnFTPSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Servidor";
            // 
            // tbcConfiguracao
            // 
            this.tbcConfiguracao.Controls.Add(this.tabListarArquivos);
            this.tbcConfiguracao.Location = new System.Drawing.Point(13, 150);
            this.tbcConfiguracao.Name = "tbcConfiguracao";
            this.tbcConfiguracao.SelectedIndex = 0;
            this.tbcConfiguracao.Size = new System.Drawing.Size(550, 377);
            this.tbcConfiguracao.TabIndex = 6;
            // 
            // tabListarArquivos
            // 
            this.tabListarArquivos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabListarArquivos.Controls.Add(this.btnFechar);
            this.tabListarArquivos.Controls.Add(this.progressBar);
            this.tabListarArquivos.Controls.Add(this.btnDownloadSelecao);
            this.tabListarArquivos.Controls.Add(this.btnEscolherDiretorioDownload);
            this.tabListarArquivos.Controls.Add(this.label9);
            this.tabListarArquivos.Controls.Add(this.txtDiretorioDestinoDownload);
            this.tabListarArquivos.Controls.Add(this.lbArquivos);
            this.tabListarArquivos.Controls.Add(this.btnListaDetalhesArquivos);
            this.tabListarArquivos.Controls.Add(this.btnListaArquivos);
            this.tabListarArquivos.Location = new System.Drawing.Point(4, 22);
            this.tabListarArquivos.Name = "tabListarArquivos";
            this.tabListarArquivos.Padding = new System.Windows.Forms.Padding(3);
            this.tabListarArquivos.Size = new System.Drawing.Size(542, 351);
            this.tabListarArquivos.TabIndex = 0;
            this.tabListarArquivos.Text = "Listar Arquivos";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(418, 297);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(118, 23);
            this.btnFechar.TabIndex = 35;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 326);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(536, 20);
            this.progressBar.TabIndex = 34;
            // 
            // btnDownloadSelecao
            // 
            this.btnDownloadSelecao.Enabled = false;
            this.btnDownloadSelecao.Location = new System.Drawing.Point(281, 297);
            this.btnDownloadSelecao.Name = "btnDownloadSelecao";
            this.btnDownloadSelecao.Size = new System.Drawing.Size(118, 23);
            this.btnDownloadSelecao.TabIndex = 13;
            this.btnDownloadSelecao.Text = "Download";
            this.btnDownloadSelecao.UseVisualStyleBackColor = true;
            this.btnDownloadSelecao.Click += new System.EventHandler(this.btnDownloadSelecao_Click);
            // 
            // btnEscolherDiretorioDownload
            // 
            this.btnEscolherDiretorioDownload.Location = new System.Drawing.Point(484, 267);
            this.btnEscolherDiretorioDownload.Name = "btnEscolherDiretorioDownload";
            this.btnEscolherDiretorioDownload.Size = new System.Drawing.Size(52, 20);
            this.btnEscolherDiretorioDownload.TabIndex = 9;
            this.btnEscolherDiretorioDownload.Text = "...";
            this.btnEscolherDiretorioDownload.UseVisualStyleBackColor = true;
            this.btnEscolherDiretorioDownload.Click += new System.EventHandler(this.btnEscolherDiretorioSelecao_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Dirertório Destino (Local)";
            // 
            // txtDiretorioDestinoDownload
            // 
            this.txtDiretorioDestinoDownload.Location = new System.Drawing.Point(9, 267);
            this.txtDiretorioDestinoDownload.Name = "txtDiretorioDestinoDownload";
            this.txtDiretorioDestinoDownload.Size = new System.Drawing.Size(470, 20);
            this.txtDiretorioDestinoDownload.TabIndex = 8;
            // 
            // lbArquivos
            // 
            this.lbArquivos.FormattingEnabled = true;
            this.lbArquivos.Location = new System.Drawing.Point(6, 39);
            this.lbArquivos.Name = "lbArquivos";
            this.lbArquivos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbArquivos.Size = new System.Drawing.Size(530, 199);
            this.lbArquivos.TabIndex = 3;
            // 
            // btnListaDetalhesArquivos
            // 
            this.btnListaDetalhesArquivos.Location = new System.Drawing.Point(294, 10);
            this.btnListaDetalhesArquivos.Name = "btnListaDetalhesArquivos";
            this.btnListaDetalhesArquivos.Size = new System.Drawing.Size(242, 23);
            this.btnListaDetalhesArquivos.TabIndex = 2;
            this.btnListaDetalhesArquivos.Text = "Listar detalhes dos Arquivos";
            this.btnListaDetalhesArquivos.UseVisualStyleBackColor = true;
            this.btnListaDetalhesArquivos.Click += new System.EventHandler(this.btnListaDetalhesArquivos_Click);
            // 
            // btnListaArquivos
            // 
            this.btnListaArquivos.Location = new System.Drawing.Point(6, 10);
            this.btnListaArquivos.Name = "btnListaArquivos";
            this.btnListaArquivos.Size = new System.Drawing.Size(242, 23);
            this.btnListaArquivos.TabIndex = 1;
            this.btnListaArquivos.Text = "Listar";
            this.btnListaArquivos.UseVisualStyleBackColor = true;
            this.btnListaArquivos.Click += new System.EventHandler(this.btnListaArquivos_Click);
            // 
            // FrmBaixarArquivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(576, 528);
            this.Controls.Add(this.tbcConfiguracao);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBaixarArquivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificação Arquivos";
            this.Load += new System.EventHandler(this.FrmListaBaixarArquivos_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tbcConfiguracao.ResumeLayout(false);
            this.tabListarArquivos.ResumeLayout(false);
            this.tabListarArquivos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPServidor;
        private System.Windows.Forms.Button btnFTPSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbcConfiguracao;
        private System.Windows.Forms.TabPage tabListarArquivos;
        private System.Windows.Forms.ListBox lbArquivos;
        private System.Windows.Forms.Button btnListaDetalhesArquivos;
        private System.Windows.Forms.Button btnListaArquivos;
        private System.Windows.Forms.Button btnEscolherDiretorioDownload;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiretorioDestinoDownload;
        private System.Windows.Forms.TextBox txtDiretorioFTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDownloadSelecao;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnFechar;
    }
}