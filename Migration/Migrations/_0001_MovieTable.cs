using FluentMigrator;


namespace Migrations.Migrations;

[Migration(1)]
public class _0001_MovieTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Movie)
                 .WithColumn("id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("movie_name").AsString(100).NotNullable().Unique();
    }
}
