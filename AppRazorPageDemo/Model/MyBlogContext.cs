using Microsoft.EntityFrameworkCore;

namespace AppRazorPageDemo.Model;

public class MyBlogContext : DbContext
{
    public MyBlogContext(DbContextOptions<MyBlogContext>options):base(options){}
    public DbSet<Article> Articles { get; set; }
}