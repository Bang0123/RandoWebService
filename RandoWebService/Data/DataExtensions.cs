using Microsoft.EntityFrameworkCore;

namespace RandoWebService.Data
{
    public static class DataExtensions
    {
        public static void Truncate<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
