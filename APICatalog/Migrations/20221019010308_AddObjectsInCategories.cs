using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    public partial class AddObjectsInCategories : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categories(Name, ImageURL) VALUES('Bebidas','bebidas.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageURL) VALUES('Lances','lances.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageURL) VALUES('Sobremesas','sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categories");
        }
    }
}
