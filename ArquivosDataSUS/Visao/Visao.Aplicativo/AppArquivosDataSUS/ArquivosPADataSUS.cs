using System;
using System.Linq;

namespace ArquivosDataSUS
{
    public class ArquivosPADataSUS : BaseAquivosDataSUS
    {
        public ArquivosPADataSUS(string servidorFTP, string usuarioFTP, string senhaFTP, string diretorioFTPArquivos, string diretorioDestinoDownload, string diretorioDestinoDBF, string estado)
            : base(servidorFTP, usuarioFTP, senhaFTP,diretorioFTPArquivos, diretorioDestinoDownload, diretorioDestinoDBF, estado, Constantes.TipoArquivoPA)
        {

         
        }

        public override string TratarNomeArquivo(string retornoFTP)
        {
            return retornoFTP;// retornoFTP.Substring(39, 12); ;
        }

        public override string TratarUFArquivo(string retornoFTP)
        {
            return this.TratarNomeArquivo(retornoFTP).Substring(2, 2);
        }

        public override string TratarTipoArquivo(string retornoFTP)
        {
            return this.TratarNomeArquivo(retornoFTP).Substring(0, 2).ToUpper();
        }

        public override int TratarDataDadosArquivo(string retornoFTP)
        {
            return Convert.ToInt32(this.TratarNomeArquivo(retornoFTP).Substring(4, 4));
        }

        public override void BuscarArquivosFTP()
        {
            //Lista todos os arquivos do diretório FTP.
            this.ListaArquivosFTP = this.ListarNomesArquivosFTP();

            //Mantenho somente os arquivos do tipo RD.
            base.ListaArquivosFTP = base.ListaArquivosFTP.Where(x => this.TratarTipoArquivo(x).Equals(base.TipoArquivo.Nome)).ToList();

            //Mantenho somente os arquivos do estado selecionado.
            base.ListaArquivosFTP = base.ListaArquivosFTP.Where(x => this.TratarUFArquivo(x).Equals(base.EstadoUF.Sigla)).ToList();
        }




    }


}
