using FluentMigrator;

namespace Infrostruckture.Migrations;

[Migration(2024122501)]
public class CreateAuthorTable : Migration
{
    public override void Up()
    {
        Create.Table("Authors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString()
            .WithColumn("Country").AsString();
    }

    public override void Down()
    {
        Delete.Table("Authors");
    }
}