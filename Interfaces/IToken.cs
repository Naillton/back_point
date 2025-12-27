namespace back_point.Interfaces
{
    public interface IToken
    {
        string GenerateToken(Guid enterpriseId, string Email, string Cnpj);
    }
}