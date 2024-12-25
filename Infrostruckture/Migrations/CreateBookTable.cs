using System.Data;
using FluentMigrator;

namespace Infrostruckture.Migrations;
[Migration(2024122502)]
public class CreateBookTable: Migration
{
    public override void Up()
    {
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString()
            .WithColumn("AuthorId").AsInt32().NotNullable().ForeignKey("Authors","Id").OnDelete(Rule.Cascade)
            .WithColumn("PublishedYear").AsInt32()
            .WithColumn("Genre").AsString()
            .WithColumn("IsAvailable").AsBoolean();
    }

    public override void Down()
    {
        Delete.Table("Books");
    }
}