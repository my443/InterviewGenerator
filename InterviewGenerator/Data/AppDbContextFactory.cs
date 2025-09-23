using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGenerator.Data
{
    public class AppDbContextFactory
    {
        /// <summary>
        /// Creates a new AppDbContext with the provided SQLite database file.
        /// </summary>
        /// <param name="sqliteDbPath">The path to the SQLite database file. Use ":memory:" for an in-memory DB.</param>
        /// <returns>A new AppDbContext instance connected to the specified database file.</returns>
        public AppDbContext CreateDbContext(string sqliteDbPath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite($"Data Source={sqliteDbPath}");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
