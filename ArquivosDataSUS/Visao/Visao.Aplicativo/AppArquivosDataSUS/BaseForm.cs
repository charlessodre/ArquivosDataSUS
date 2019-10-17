using Application;
using Domain.Entity;
using Infrastructure.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace ArquivosDataSUS
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        #region Atributos

        private bool _fecharFormulario = false;

        #endregion

        #region Propriedades

        public bool FecharFormulario
        {
            get { return _fecharFormulario; }
            set { _fecharFormulario = value; }
        }

        public System.Drawing.Icon IconeEmExecucao
        {
            get { return  new System.Drawing.Icon(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Constantes.PathIconeEmExecucao)); }
            
        }

        public System.Drawing.Icon PathIconeDefault
        {
            get { return new System.Drawing.Icon(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Constantes.PathIconeDefault)); }

        }
        

        #endregion

        #region Métodos Públicos

      

        /// <summary>
        ///  Exibe a mensagem qualquer.
        /// </summary>
        /// <param name="pMensagem">Mensagem a ser exibida.</param>
        /// <param name="pTituloJanela">Título da janela de mensagem.</param>
        /// <param name="pTipoBotao">Tipo do botão.</param>
        /// <param name="pTipoIcone">Tipo de icone da mensagem</param>
        /// <param name="pBotaoSelecioando">Botão selecioando</param>
        /// <returns>Retorna o resultado.</returns>
        public DialogResult ExibirMessagemGeral(string pMensagem, string pTituloJanela, MessageBoxButtons pTipoBotao, MessageBoxIcon pTipoIcone, MessageBoxDefaultButton pBotaoSelecioando)
        {
            return MessageBox.Show(pMensagem, pTituloJanela, pTipoBotao, pTipoIcone, pBotaoSelecioando);
        }


        
        #endregion


    }
}
