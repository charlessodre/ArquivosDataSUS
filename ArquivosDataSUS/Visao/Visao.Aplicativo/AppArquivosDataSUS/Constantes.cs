using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivosDataSUS
{
    public static class Constantes
    {
        /// <summary>
        /// Milissegundos 300000 = 5 minutos
        /// </summary>
        public static int TempoEsperaConversao { get { return 300000; } }
        public static string PathIconeDefault { get { return "icones\\icone.ico"; } }
        public static string PathIconeEmExecucao { get { return "icones\\iconeExc.ico"; } }
        public static string ProgramaConversaoDBF2DBC { get { return "dbf2dbc\\dbf2dbc.exe"; } }
        public static string ExtensaoArquivosDBC { get { return ".dbc"; } }
        public static string ExtensaoArquivosDBF { get { return ".dbf"; } }
        public static string TipoArquivoDBF { get { return "DBF"; } }
        public static string TipoArquivoRD { get { return "RD"; } }
        public static string TipoArquivoPA { get { return "PA"; } }
        public static string TipoArquivoRJ { get { return "RJ"; } }
        public static string FormatoDataHora { get { return "dd/MM/yyyy HH:mm:ss"; } }
        public static string ChaveAppServidorFTP { get { return "ServidorOrigemFTP"; } }
        public static string ChaveAppDiretorioFTP_Arq_RD { get { return "DiretorioOrigemFTP_Arq_RD"; } }
        public static string ChaveAppDiretorioFTP_Arq_RJ { get { return "DiretorioOrigemFTP_Arq_RJ"; } }
        public static string ChaveAppDiretorioFTP_Arq_PA { get { return "DiretorioOrigemFTP_Arq_PA"; } }
        public static string ChaveAppUsuarioServidorOrigemFTP { get { return "UsuarioServidorOrigemFTP"; } }
        public static string ChaveAppSenhaUsuarioServidorOrigemFTP { get { return "SenhaUsuarioServidorOrigemFTP"; } }
        public static string ChaveAppDiretorioDestinoArquivosFTP { get { return "DiretorioDestinoArquivosFTP"; } }
        public static string ChaveAppUFArquivosDownload { get { return "UFArquivosDownload"; } }
        public static string ChaveAppFrequenciaExecucao { get { return "FrequenciaExecucao"; } }
        public static string ChaveAppHoraExecucao { get { return "HoraExecucao"; } }
        public static string ChaveAppMinutoExecucao { get { return "MinutoExecucao"; } }
        public static string ChaveAppExecucaoAcadaMinutos { get { return "ExecucaoAcadaMinutos"; } }
        public static string ChaveAppTiposArquivos { get { return "TiposArquivos"; } }
        public static string ChaveAppDiretorioDestinoArquivosDBF { get { return "DiretorioDestinoArquivosDBF"; } }
        public static string ChaveAppBaixarSomenteAruivosModificados { get { return "BaixarSomenteAruivosModificados"; } }
    

        /// <summary>
        /// Formar o TimeSpan em 0 horas 0 minutos 0 segundos
        /// </summary>
        /// <param name="timeSpan">TimeSpan</param>
        /// <returns>retorna o TimeSpan formatado</returns>
        public static string FormartarTimeSpan(TimeSpan timeSpan)
        {
            return string.Format("{0:%h} horas {0:%m} minutos {0:%s} segundos", timeSpan);
        }

        public static string FormartarInfoLogArquivo(Arquivo aquivo)
        {
            return string.Format("Arquivo: {0} - Local Destino DBC: {1} - Local Destino DBF: {2} - Data Modificação: {3} - Tamanho: {4}",
                aquivo.Nome, aquivo.LocalDestino, aquivo.LocalDestinoDBF, aquivo.DataModificacao, aquivo.Tamanho);
        }
    }


}
