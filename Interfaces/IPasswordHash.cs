namespace back_point.Interfaces
{
    public interface IPasswordHash
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}