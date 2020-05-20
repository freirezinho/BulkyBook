using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class AddStoredProcForCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE usp_GetCoverTypes()
                                    BEGIN
                                        SELECT * FROM CoverTypes;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_GetCoverType
                                    (
                                        id int
                                    )
                                    BEGIN 
                                     SELECT * FROM CoverTypes WHERE CoverTypes.Id=id;
                                    END;");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_UpdateCoverType
                                    (
                                        id int,
                                        name varchar(100)
                                    )
                                    BEGIN 
                                     UPDATE CoverTypes SET  CoverTypes.Name = name
                                     WHERE  CoverTypes.Id = id;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_DeleteCoverType
                                    (
                                        id int
                                    )
                                    BEGIN 
                                     DELETE FROM CoverTypes WHERE CoverTypes.Id = id;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_CreateCoverType
                                   (
                                        name varchar(100)
                                   )
                                   BEGIN 
                                    INSERT INTO CoverTypes(name) VALUES (name);
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoverType");
        }
    }
}
