namespace LocalizarCep.Dominio.Entidade
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrWhiteSpace(Login))
                return false;

            if (Login.Length < 2 || Login.Length > 10)
                return false;

            if (string.IsNullOrEmpty(Senha) || string.IsNullOrWhiteSpace(Senha))
                return false;

            if (Senha.Length < 2)
                return false;

            return true;
        }
    }
}
