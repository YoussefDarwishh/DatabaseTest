using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migration.Migrations;

[Migration(3)]
public class _0003_MovieDatabaseSeed : AutoReversingMigration
{
    public override void Up()
    {
        Insert.IntoTable("movie")
            .Row(new
            {
                movie_name = "The Shawshank Redemption"
            })
            .Row(new
            {
                movie_name = "The Godfather"
            })
            .Row(new
            {
                movie_name = "The Dark Knight"
            });

        Insert.IntoTable("movieinfo")
            .Row(new
            {
                movie_id = 1,
                director = "Frank Darabont",
                genre = "Drama"
            })
            .Row(new
            {
                movie_id = 2,
                director = "Francis Ford Coppola",
                genre = "Crime"
            })
            .Row(new
            {
                movie_id = 3,
                director = "Christopher Nolan",
                genre = "Action"
            });
    }
}
