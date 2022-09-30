using System;
using AppRazorPageDemo.Model;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRazorPageDemo.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2000, 1, 1),new DateTime(2022,1,1)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1 , 4));
            for (int i = 0; i < 200; i++)
            {
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                
                    table: "Articles",
                    columns: new[] { "Title", "Content", "Created" },
                    values:new object[]
                    {
                        article.Title,
                        article.Content,
                        article.Created
                    });
            }
            
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
