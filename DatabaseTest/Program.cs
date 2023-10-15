using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using Npgsql;
using FavMovies.DatabaseSpecific;
using FavMovies.Linq;
using Database_Test.Models;
using SD.LLBLGen.Pro.LinqSupportClasses;
using FavMovies.EntityClasses;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Postgres");
RuntimeConfiguration.AddConnectionString("Postgres", builder.Configuration.GetConnectionString("Postgres"));
RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(c =>
{
    c.AddDbProviderFactory(typeof(NpgsqlFactory));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/get_movies", async (HttpContext context) =>
    {
        using (var adapter = new DataAccessAdapter(connectionString))
        {
            try
            {
                var metaData = new LinqMetaData(adapter);
                var movies = await metaData.Movieinfo.ToListAsync();

                var html = "<html><head><title>Movies</title></head><body><h1>Movies List</h1><ul>";

                foreach (var movie in movies)
                {
                    html += $"<li><b>Movie ID:</b> {movie.MovieId}<br><b>Director:</b> {movie.Director}<br><b>Genre:</b> {movie.Genre}</li>";
                }

                html += "</ul></body></html>";


                context.Response.ContentType = "text/html";


                await context.Response.WriteAsync(html);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    });

app.MapPost("/add-movie", async ([FromBody] Movie movie) =>
{
    using (var adapter = new DataAccessAdapter(connectionString))
    {
        try
        {
            MovieEntity movieEntity = new()
            {
                MovieName = movie.Name,
                Id = movie.Id
            };
            await adapter.SaveEntityAsync(movieEntity, true);

            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
});

app.UseHttpsRedirection();
app.Run();