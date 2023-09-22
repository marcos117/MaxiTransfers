using Microsoft.EntityFrameworkCore;

namespace Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }

}