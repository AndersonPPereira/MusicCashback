using MusicCashback.Domain.Validation;

namespace MusicCashback.Application.Dto.Cliente
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }


        public bool IsNotValid()
        {
            return string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(LimpaCpf()) || string.IsNullOrEmpty(Senha); 
        }

        public bool CpfValid()
        {
            return CpfValidation.IsValid(Cpf);
        }

        private string LimpaCpf()
        {
            return Cpf = CpfValidation.Limpa(Cpf);
        }
    }
}
