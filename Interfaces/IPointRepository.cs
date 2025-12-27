namespace back_point.Interfaces
{
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPointRepository
    {
        Task<Point> CreatePoint(Point point);
        Task<Point?> GetPointById(Guid id);
        Task<List<Point>> GetPointsByUserId(Guid userId);
        Task<Point> UpdatePoint(Point point);
        Task<bool> DeletePoint(Guid id);
    }
}