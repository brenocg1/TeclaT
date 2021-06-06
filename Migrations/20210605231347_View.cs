using Microsoft.EntityFrameworkCore.Migrations;

namespace TeclaT.Migrations
{
    public partial class View : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW VW_PRODUCTS
					AS

						SELECT P.ID
							,P.Name
							,P.SKUCode
							,P.Price
							,P.Description
							,S.Id AS SubCategoryId
							,S.Name AS SubCategory
							,C.Id AS CategoryId
							,C.Name AS Category
						FROM Products P 
						JOIN SubCategories S ON P.SubCategoryId = S.Id
						JOIN Categories C ON S.CategoryId = C.Id
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"drop view VW_PRODUCTS;");
		}
    }
}
