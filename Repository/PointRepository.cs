namespace back_point.Repository
{
    using back_point.Interfaces;
    using back_point.Models;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class PointRepository : IPointRepository
    {
        private readonly PointContext _context;

        public PointRepository(PointContext context)
        {
            _context = context;
        }

        public async Task<Point> CreatePoint(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
            return point;
        }

        public async Task<bool> DeletePoint(Guid id)
        {
            var point = await _context.Points.FindAsync(id);
            if (point == null)
            {
                return false;
            }

            _context.Points.Remove(point);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Point?> GetPointById(Guid id)
        {
            return await _context.Points.FindAsync(id);
        }

        public async Task<List<Point>> GetPointsByUserId(Guid userId)
        {
            return await _context.Points
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Point> UpdatePoint(Point point)
        {
            _context.Points.Update(point);
            await _context.SaveChangesAsync();
            return point;
        }
    }
}