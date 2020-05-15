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

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_GetCoverType(IN id INT)
                                    BEGIN 
                                     SELECT * FROM CoverTypes  WHERE Id = id;
                                    END ");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_UpdateCoverType(IN id INT, IN name VARCHAR(100))
                                    BEGIN 
                                     UPDATE CoverTypes
                                     SET  Name = name
                                     WHERE  Id = id;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_DeleteCoverType(IN id INT)
                                    BEGIN 
                                     DELETE FROM CoverTypes
                                     WHERE  Id = id;
                                    END");

            migrationBuilder.Sql(@"CREATE PROCEDURE usp_CreateCoverType(IN name VARCHAR(100))
                                   BEGIN 
                                    INSERT INTO CoverTypes(name)
                                    VALUES (name);
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
