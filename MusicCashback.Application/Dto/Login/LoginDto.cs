namespace MusicCashback.Application.Dto.Login
{
    public class LoginDto
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }

        public bool IsNotValid() 
        {
            return string.IsNullOrEmpty(Cpf) || string.IsNullOrEmpty(Senha); 
        }
    }
}
