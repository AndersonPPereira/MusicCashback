using System;

namespace MusicCashback.Domain.Exceptions.Common
{
    public class ExceptionData
    {
        public static void GetInfoDataException(string Tabela, Exception ex)
        {
            var innerMessage = ex?.InnerException != null ? ex.InnerException.Message : "Não encontrado";
            var message = ex != null ? ex.Message : "Não encontrado";
            var source = ex != null ? ex.Source : "Não encontrado";
            var method = ex?.TargetSite?.DeclaringType != null ? ex.TargetSite.DeclaringType.FullName : "Não encontrado";
            var namespaceName = ex?.TargetSite?.DeclaringType != null ? ex.TargetSite.DeclaringType.Namespace : "Não encontrado";
            var stackTrace = ex != null ? ex.StackTrace : "Não encontrado";

            new ThwoException($@"
                Tabela: {Tabela} \n
                Date and Time: { DateTime.Now} \n
                InnerException: {innerMessage} \n
                Message: {message} \n
                Source: { source} \n
                Method: { method} \n
                Namespace: { namespaceName} \n
                StackTrace: { stackTrace}
                ");
        }
    }

    public class ThwoException : Exception
    {
        public ThwoException(string message) : base(message)
        {

        }
    }
}
