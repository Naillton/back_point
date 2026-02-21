namespace back_point.Interfaces
{
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPoint
    {
        Task<Point> CreatePoint(string code);
        Task<Point?> GetPointById(Guid id);
        Task<List<Point>> GetPointsByUserCode(string code);
        Task<Point> UpdatePoint(Point point);
        Task<bool> DeletePoint(Guid id);
    }
}