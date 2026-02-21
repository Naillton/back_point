namespace back_point.Services
{
    using back_point.DTO;
    using back_point.Models;

    // criando mapper para converter User para UserResponseDTO
    // desta forma, evitamos expor a senha e outras informações sensíveis do usuário na resposta da API
    public static class MapperService
    {
        public static UserResponseDTO ToUserResponseDTO(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Code = user.code,
                Points = user.Points.Select(p => new PointResponseDTO
                {
                    Id = p.Id,
                    DateHour = p.DateHour,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Code = p.code
                }).ToList()
            };
        }
    }
}
