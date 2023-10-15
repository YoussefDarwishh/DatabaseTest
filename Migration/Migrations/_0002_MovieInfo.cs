using FluentMigrator;


namespace Migrations.Migrations;

[Migration(2)]
public class _0002_MovieInfo : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.MovieInfo)
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("movie_id").AsInt32().ForeignKey("movie", "id")
                .WithColumn("director").AsString(100).Nullable()
                .WithColumn("genre").AsString(50).Nullable();
    }
}
