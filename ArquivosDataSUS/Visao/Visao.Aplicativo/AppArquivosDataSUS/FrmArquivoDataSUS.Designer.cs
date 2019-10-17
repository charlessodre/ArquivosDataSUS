namespace ArquivosDataSUS
{
    partial class FrmArquivoDataSUS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArquivoDataSUS));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtDiretorioFTP_PA = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiretorioFTP_RJ = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiretorioFTP_RD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IcNotificacao = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDestinoDBF = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDestinoDBF = new System.Windows.Forms.TextBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.btnEscolherDiretorioDownload = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiretorioDestinoDownload = new System.Windows.Forms.TextBox();
            this.lblTipoArquivos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOcultar = new System.Windows.Forms.Button();
            this.btnExecutarAgora = new System.Windows.Forms.Button();
            this.gbxExecutar = new System.Windows.Forms.GroupBox();
            this.btnAgendarExecucao = new System.Windows.Forms.Button();
            this.lblStatusApp = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblExecucao = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gbxAgendamento = new System.Windows.Forms.GroupBox();
            this.cbxAcadaMinuto = new System.Windows.Forms.CheckBox();
            this.gbxAcadaMinuto = new System.Windows.Forms.GroupBox();
            this.nudCadaMinuto = new System.Windows.Forms.NumericUpDown();
            this.lblProximaExecucao = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblUltimaExecucao = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlDiaAgendamento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMinuto = new System.Windows.Forms.NumericUpDown();
            this.nudHora = new System.Windows.Forms.NumericUpDown();
            this.lblBarraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mniArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarConfiguraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxExecutar.SuspendLayout();
            this.gbxAgendamento.SuspendLayout();
            this.gbxAcadaMinuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCadaMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHora)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.txtDiretorioFTP_PA);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.txtDiretorioFTP_RJ);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txtDiretorioFTP_RD);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.txtSenha);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtUsuario);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtIPServidor);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(13, 27);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(550, 172);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Configurações FTP";
            // 
            // txtDiretorioFTP_PA
            // 
            this.txtDiretorioFTP_PA.Location = new System.Drawing.Point(5, 141);
            this.txtDiretorioFTP_PA.Name = "txtDiretorioFTP_PA";
            this.txtDiretorioFTP_PA.Size = new System.Drawing.Size(538, 20);
            this.txtDiretorioFTP_PA.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(3, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Dirertório do FTP Arquivos PA";
            // 
            // txtDiretorioFTP_RJ
            // 
            this.txtDiretorioFTP_RJ.Location = new System.Drawing.Point(6, 105);
            this.txtDiretorioFTP_RJ.Name = "txtDiretorioFTP_RJ";
            this.txtDiretorioFTP_RJ.Size = new System.Drawing.Size(538, 20);
            this.txtDiretorioFTP_RJ.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(4, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Dirertório do FTP Arquivos RJ";
            // 
            // txtDiretorioFTP_RD
            // 
            this.txtDiretorioFTP_RD.Location = new System.Drawing.Point(6, 69);
            this.txtDiretorioFTP_RD.Name = "txtDiretorioFTP_RD";
            this.txtDiretorioFTP_RD.Size = new System.Drawing.Size(538, 20);
            this.txtDiretorioFTP_RD.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Dirertório do FTP Arquivos RD";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Servidor";
            // 
            // IcNotificacao
            // 
            this.IcNotificacao.Icon = ((System.Drawing.Icon)(resources.GetObject("IcNotificacao.Icon")));
            this.IcNotificacao.Text = "Arquivos DataSUS";
            this.IcNotificacao.Visible = true;
            this.IcNotificacao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IcNotificacao_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDestinoDBF);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDestinoDBF);
            this.groupBox2.Controls.Add(this.lblUF);
            this.groupBox2.Controls.Add(this.btnEscolherDiretorioDownload);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDiretorioDestinoDownload);
            this.groupBox2.Controls.Add(this.lblTipoArquivos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 123);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurações para Download";
            // 
            // btnDestinoDBF
            // 
            this.btnDestinoDBF.Location = new System.Drawing.Point(483, 95);
            this.btnDestinoDBF.Name = "btnDestinoDBF";
            this.btnDestinoDBF.Size = new System.Drawing.Size(52, 20);
            this.btnDestinoDBF.TabIndex = 53;
            this.btnDestinoDBF.Text = "...";
            this.btnDestinoDBF.UseVisualStyleBackColor = true;
            this.btnDestinoDBF.Click += new System.EventHandler(this.btnDestinoDBF_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Dirertório Destino Aquivos Convertidos (DBF)";
            // 
            // txtDestinoDBF
            // 
            this.txtDestinoDBF.Location = new System.Drawing.Point(5, 95);
            this.txtDestinoDBF.Name = "txtDestinoDBF";
            this.txtDestinoDBF.Size = new System.Drawing.Size(470, 20);
            this.txtDestinoDBF.TabIndex = 52;
            // 
            // lblUF
            // 
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUF.Location = new System.Drawing.Point(42, 24);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(25, 13);
            this.lblUF.TabIndex = 51;
            this.lblUF.Text = "RJ";
            // 
            // btnEscolherDiretorioDownload
            // 
            this.btnEscolherDiretorioDownload.Location = new System.Drawing.Point(483, 59);
            this.btnEscolherDiretorioDownload.Name = "btnEscolherDiretorioDownload";
            this.btnEscolherDiretorioDownload.Size = new System.Drawing.Size(52, 20);
            this.btnEscolherDiretorioDownload.TabIndex = 42;
            this.btnEscolherDiretorioDownload.Text = "...";
            this.btnEscolherDiretorioDownload.UseVisualStyleBackColor = true;
            this.btnEscolherDiretorioDownload.Click += new System.EventHandler(this.btnEscolherDiretorioDownload_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Dirertório Destino Aquivos FTP (Local)";
            // 
            // txtDiretorioDestinoDownload
            // 
            this.txtDiretorioDestinoDownload.Location = new System.Drawing.Point(5, 59);
            this.txtDiretorioDestinoDownload.Name = "txtDiretorioDestinoDownload";
            this.txtDiretorioDestinoDownload.Size = new System.Drawing.Size(470, 20);
            this.txtDiretorioDestinoDownload.TabIndex = 41;
            // 
            // lblTipoArquivos
            // 
            this.lblTipoArquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArquivos.Location = new System.Drawing.Point(190, 24);
            this.lblTipoArquivos.Name = "lblTipoArquivos";
            this.lblTipoArquivos.Size = new System.Drawing.Size(200, 13);
            this.lblTipoArquivos.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Tipos de Arquivos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Estado:";
            // 
            // btnOcultar
            // 
            this.btnOcultar.Location = new System.Drawing.Point(476, 48);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(66, 23);
            this.btnOcultar.TabIndex = 51;
            this.btnOcultar.Text = "Ocultar";
            this.btnOcultar.UseVisualStyleBackColor = true;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // btnExecutarAgora
            // 
            this.btnExecutarAgora.Location = new System.Drawing.Point(8, 48);
            this.btnExecutarAgora.Name = "btnExecutarAgora";
            this.btnExecutarAgora.Size = new System.Drawing.Size(118, 23);
            this.btnExecutarAgora.TabIndex = 43;
            this.btnExecutarAgora.Text = "Executar Agora";
            this.btnExecutarAgora.UseVisualStyleBackColor = true;
            this.btnExecutarAgora.Click += new System.EventHandler(this.btnExecutarAgora_Click);
            // 
            // gbxExecutar
            // 
            this.gbxExecutar.Controls.Add(this.btnAgendarExecucao);
            this.gbxExecutar.Controls.Add(this.lblStatusApp);
            this.gbxExecutar.Controls.Add(this.label17);
            this.gbxExecutar.Controls.Add(this.lblExecucao);
            this.gbxExecutar.Controls.Add(this.label16);
            this.gbxExecutar.Controls.Add(this.btnOcultar);
            this.gbxExecutar.Controls.Add(this.btnExecutarAgora);
            this.gbxExecutar.Location = new System.Drawing.Point(13, 424);
            this.gbxExecutar.Name = "gbxExecutar";
            this.gbxExecutar.Size = new System.Drawing.Size(551, 77);
            this.gbxExecutar.TabIndex = 30;
            this.gbxExecutar.TabStop = false;
            this.gbxExecutar.Text = "Executar";
            // 
            // btnAgendarExecucao
            // 
            this.btnAgendarExecucao.Location = new System.Drawing.Point(164, 48);
            this.btnAgendarExecucao.Name = "btnAgendarExecucao";
            this.btnAgendarExecucao.Size = new System.Drawing.Size(118, 23);
            this.btnAgendarExecucao.TabIndex = 54;
            this.btnAgendarExecucao.Text = "Agendar Execução";
            this.btnAgendarExecucao.UseVisualStyleBackColor = true;
            this.btnAgendarExecucao.Click += new System.EventHandler(this.btnAgendarExecucao_Click);
            // 
            // lblStatusApp
            // 
            this.lblStatusApp.AutoSize = true;
            this.lblStatusApp.Location = new System.Drawing.Point(407, 21);
            this.lblStatusApp.Name = "lblStatusApp";
            this.lblStatusApp.Size = new System.Drawing.Size(16, 13);
            this.lblStatusApp.TabIndex = 53;
            this.lblStatusApp.Text = "...";
            this.lblStatusApp.TextChanged += new System.EventHandler(this.lblStatusApp_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(366, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "Status:";
            // 
            // lblExecucao
            // 
            this.lblExecucao.AutoSize = true;
            this.lblExecucao.Location = new System.Drawing.Point(142, 21);
            this.lblExecucao.Name = "lblExecucao";
            this.lblExecucao.Size = new System.Drawing.Size(31, 13);
            this.lblExecucao.TabIndex = 12;
            this.lblExecucao.Text = "--:--:--";
            this.lblExecucao.TextChanged += new System.EventHandler(this.lblExecucao_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Tempo da última execução:";
            // 
            // gbxAgendamento
            // 
            this.gbxAgendamento.Controls.Add(this.cbxAcadaMinuto);
            this.gbxAgendamento.Controls.Add(this.gbxAcadaMinuto);
            this.gbxAgendamento.Controls.Add(this.lblProximaExecucao);
            this.gbxAgendamento.Controls.Add(this.label14);
            this.gbxAgendamento.Controls.Add(this.lblUltimaExecucao);
            this.gbxAgendamento.Controls.Add(this.label12);
            this.gbxAgendamento.Controls.Add(this.label11);
            this.gbxAgendamento.Controls.Add(this.ddlDiaAgendamento);
            this.gbxAgendamento.Controls.Add(this.label10);
            this.gbxAgendamento.Controls.Add(this.label8);
            this.gbxAgendamento.Controls.Add(this.nudMinuto);
            this.gbxAgendamento.Controls.Add(this.nudHora);
            this.gbxAgendamento.Location = new System.Drawing.Point(13, 328);
            this.gbxAgendamento.Name = "gbxAgendamento";
            this.gbxAgendamento.Size = new System.Drawing.Size(550, 90);
            this.gbxAgendamento.TabIndex = 31;
            this.gbxAgendamento.TabStop = false;
            this.gbxAgendamento.Text = "Agendamento Execução";
            // 
            // cbxAcadaMinuto
            // 
            this.cbxAcadaMinuto.AutoSize = true;
            this.cbxAcadaMinuto.Location = new System.Drawing.Point(349, 19);
            this.cbxAcadaMinuto.Name = "cbxAcadaMinuto";
            this.cbxAcadaMinuto.Size = new System.Drawing.Size(15, 14);
            this.cbxAcadaMinuto.TabIndex = 14;
            this.cbxAcadaMinuto.UseVisualStyleBackColor = true;
            this.cbxAcadaMinuto.CheckedChanged += new System.EventHandler(this.cbxAcadaMinuto_CheckedChanged);
            // 
            // gbxAcadaMinuto
            // 
            this.gbxAcadaMinuto.Controls.Add(this.nudCadaMinuto);
            this.gbxAcadaMinuto.Enabled = false;
            this.gbxAcadaMinuto.Location = new System.Drawing.Point(213, 19);
            this.gbxAcadaMinuto.Name = "gbxAcadaMinuto";
            this.gbxAcadaMinuto.Size = new System.Drawing.Size(153, 61);
            this.gbxAcadaMinuto.TabIndex = 12;
            this.gbxAcadaMinuto.TabStop = false;
            this.gbxAcadaMinuto.Text = "Executar a cada Minutos:";
            // 
            // nudCadaMinuto
            // 
            this.nudCadaMinuto.Location = new System.Drawing.Point(36, 25);
            this.nudCadaMinuto.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.nudCadaMinuto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCadaMinuto.Name = "nudCadaMinuto";
            this.nudCadaMinuto.Size = new System.Drawing.Size(83, 20);
            this.nudCadaMinuto.TabIndex = 13;
            this.nudCadaMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCadaMinuto.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // lblProximaExecucao
            // 
            this.lblProximaExecucao.Location = new System.Drawing.Point(396, 70);
            this.lblProximaExecucao.Name = "lblProximaExecucao";
            this.lblProximaExecucao.Size = new System.Drawing.Size(140, 13);
            this.lblProximaExecucao.TabIndex = 11;
            this.lblProximaExecucao.Text = "--/--/---- --:--:--";
            this.lblProximaExecucao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProximaExecucao.TextChanged += new System.EventHandler(this.lblProximaExecucao_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(417, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Próxima Execução:";
            // 
            // lblUltimaExecucao
            // 
            this.lblUltimaExecucao.Location = new System.Drawing.Point(396, 29);
            this.lblUltimaExecucao.Name = "lblUltimaExecucao";
            this.lblUltimaExecucao.Size = new System.Drawing.Size(140, 13);
            this.lblUltimaExecucao.TabIndex = 9;
            this.lblUltimaExecucao.Text = "--/--/---- --:--:--";
            this.lblUltimaExecucao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUltimaExecucao.TextChanged += new System.EventHandler(this.lblUltimaExecucao_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(421, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Última Execução:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Frequência:";
            // 
            // ddlDiaAgendamento
            // 
            this.ddlDiaAgendamento.FormattingEnabled = true;
            this.ddlDiaAgendamento.Location = new System.Drawing.Point(76, 27);
            this.ddlDiaAgendamento.Name = "ddlDiaAgendamento";
            this.ddlDiaAgendamento.Size = new System.Drawing.Size(121, 21);
            this.ddlDiaAgendamento.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Minutos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Hora:";
            // 
            // nudMinuto
            // 
            this.nudMinuto.Location = new System.Drawing.Point(154, 58);
            this.nudMinuto.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinuto.Name = "nudMinuto";
            this.nudMinuto.Size = new System.Drawing.Size(35, 20);
            this.nudMinuto.TabIndex = 2;
            this.nudMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinuto.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // nudHora
            // 
            this.nudHora.Location = new System.Drawing.Point(44, 58);
            this.nudHora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHora.Name = "nudHora";
            this.nudHora.Size = new System.Drawing.Size(35, 20);
            this.nudHora.TabIndex = 0;
            this.nudHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBarraStatus
            // 
            this.lblBarraStatus.AutoSize = false;
            this.lblBarraStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarraStatus.Name = "lblBarraStatus";
            this.lblBarraStatus.Size = new System.Drawing.Size(570, 19);
            this.lblBarraStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBarraStatus.TextChanged += new System.EventHandler(this.lblBarraStatus_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBarraStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(576, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mniArquivo
            // 
            this.mniArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarConfiguraçãoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.mniArquivo.Name = "mniArquivo";
            this.mniArquivo.Size = new System.Drawing.Size(61, 20);
            this.mniArquivo.Text = "&Arquivo";
            // 
            // gerarConfiguraçãoToolStripMenuItem
            // 
            this.gerarConfiguraçãoToolStripMenuItem.Name = "gerarConfiguraçãoToolStripMenuItem";
            this.gerarConfiguraçãoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.gerarConfiguraçãoToolStripMenuItem.Text = "&Utilitário FTP";
            this.gerarConfiguraçãoToolStripMenuItem.Click += new System.EventHandler(this.gerarConfiguraçãoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sairToolStripMenuItem.Text = "Sai&r";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // mniAjuda
            // 
            this.mniAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.mniAjuda.Name = "mniAjuda";
            this.mniAjuda.Size = new System.Drawing.Size(50, 20);
            this.mniAjuda.Text = "&Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "&Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniArquivo,
            this.mniAjuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menu";
            // 
            // FrmArquivoDataSUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(576, 535);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbxAgendamento);
            this.Controls.Add(this.gbxExecutar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmArquivoDataSUS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arquivos DATASUS";
            this.MinimumSizeChanged += new System.EventHandler(this.FrmArquivoDataSUS_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmArquivoDataSUS_FormClosing);
            this.Load += new System.EventHandler(this.FrmListaBaixarArquivos_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxExecutar.ResumeLayout(false);
            this.gbxExecutar.PerformLayout();
            this.gbxAgendamento.ResumeLayout(false);
            this.gbxAgendamento.PerformLayout();
            this.gbxAcadaMinuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCadaMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHora)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiretorioFTP_RD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon IcNotificacao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOcultar;
        private System.Windows.Forms.Button btnExecutarAgora;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbxExecutar;
        private System.Windows.Forms.GroupBox gbxAgendamento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMinuto;
        private System.Windows.Forms.NumericUpDown nudHora;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlDiaAgendamento;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblProximaExecucao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblUltimaExecucao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTipoArquivos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.Button btnDestinoDBF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestinoDBF;
        private System.Windows.Forms.Button btnEscolherDiretorioDownload;
        private System.Windows.Forms.TextBox txtDiretorioDestinoDownload;
        private System.Windows.Forms.TextBox txtDiretorioFTP_PA;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDiretorioFTP_RJ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblExecucao;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStatusApp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripMenuItem mniArquivo;
        private System.Windows.Forms.ToolStripMenuItem gerarConfiguraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniAjuda;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnAgendarExecucao;
        private System.Windows.Forms.GroupBox gbxAcadaMinuto;
        private System.Windows.Forms.NumericUpDown nudCadaMinuto;
        private System.Windows.Forms.CheckBox cbxAcadaMinuto;
    }
}