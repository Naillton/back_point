namespace back_point.Services
{
    using back_point.Interfaces;
    using back_point.Models;
    using back_point.Repository;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class PointService : IPoint
    {
        private readonly IPointRepository _pointRepository;
        private readonly PointContext _context;
        private readonly Random _random = new();

        public PointService(IPointRepository pointRepository, PointContext context)
        {
            _pointRepository = pointRepository;
            _context = context;
        }

        public async Task<Point> CreatePoint(string code)
        {
            var userExists = await _context.Users.AnyAsync(u => u.code == code);
            if (!userExists)
            {
                throw new ArgumentException($"User with code '{code}' not found.");
            }

            Point newPoint = new Point
            {
                DateHour = DateTime.Now,
                code = code,
                Latitude = _random.NextDouble() * (-5.0 + 33.7) - 33.7,
                Longitude = _random.NextDouble() * (-34.8 + 73.9) - 73.9
            };

            return await _pointRepository.CreatePoint(newPoint);
        }

        public Task<bool> DeletePoint(Guid id)
        {
            _pointRepository.DeletePoint(id);
            return Task.FromResult(true);
        }

        public Task<Point?> GetPointById(Guid id)
        {
            return _pointRepository.GetPointById(id);
        }

        public Task<List<Point>> GetPointsByUserCode(string code)
        {
            return _pointRepository.GetPointsByUserCode(code);
        }

        public Task<Point> UpdatePoint(Point point)
        {
            return _pointRepository.UpdatePoint(point);
        }
    }
}