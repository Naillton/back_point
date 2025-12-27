namespace back_point.Services
{
    using back_point.Interfaces;
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class PointService : IPoint
    {
        private readonly IPointRepository _pointRepository;
        private readonly Random _random = new();
        
        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;;
        }

        public Task<Point> CreatePoint(Guid userId)
        {
            Point newPoint = new Point
            {
                DateHour = DateTime.Now,
                UserId = userId,

                Latitude = _random.NextDouble() * (-5.0 + 33.7) - 33.7,
                Longitude = _random.NextDouble() * (-34.8 + 73.9) - 73.9
            };
            return _pointRepository.CreatePoint(newPoint);
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

        public Task<List<Point>> GetPointsByUserId(Guid userId)
        {
            return _pointRepository.GetPointsByUserId(userId);
        }

        public Task<Point> UpdatePoint(Point point)
        {
            return _pointRepository.UpdatePoint(point);  
        }
    }
}