namespace MusicCashback.Domain.Exceptions.Common
{
    public class ExceptionMessages
    {
        #region Comum
        public static string ErroAoSalvarDados => "Ocorreu um erro ao salvar os dados";
        public static string ObjetoInvalido => "Infome todos os campos.";
        public static string ErroAoInserirDadosComChaveDuplicada => "Não é possível inserir dados com valor único já existente";
        #endregion

        #region Login
        public static string LoginExistente => "Login já existente";
        public static string LoginInexistente => "Login não existe";
        #endregion

        #region Cliente
        public static string CpfESenhaEmBranco => "Informe cpf e senha.";
        public static string CpfJaCadastrado => "Já existe um cliente cadastro com esse cpf.";
        public static string CpfInvalido => "Cpf inválido.";
        public static string InformeUmCliente => "Informe um cliente.";
        public static string ClienteNaoEncontrado => "Cliente não encontrado.";
        public static string ClienteSemPermissao => "Não foi possível alterar o Cliente.";
        public static string ClienteExcluido => "Cliente excluido com sucesso.";
        public static string ClienteSemVendas => "Cliente não possui nenhuma venda.";
        public static string ClienteDadosInvalidos => "Cliente com dados invalidos.";
        #endregion

        #region Pedido

        public static string DiscoNaoEncontrado => "Disco(s) não encontrado(s).";

        #endregion

        #region Venda
        public static string VendaIdNaoInformado => "Informe uma venda para consulta.";
        public static string VendaRangeDatasInvalido => "Range de datas inválido.";
        public static string VendaNaoEncontrada => "Nenhuma venda encontrada.";
        #endregion

        #region Disco
        public static string DiscoIdNaoInformado => "Informe um disco para consulta";
        public static string DiscoNaoEncontrada => "Nenhum disco encontrado.";
        #endregion
    }
}
