using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    public partial class AddObjectsInProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, ImageURL, Inventory, CreationDate, CategoryId) " +
                   "VALUES('Coca-Cola Diet','Refrigerante de Cola 350ml', '5.45', 'cocacola.jpg', 50, now(),1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
