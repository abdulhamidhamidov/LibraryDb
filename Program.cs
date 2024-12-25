using FluentMigrator.Runner;
using Infrostruckture.Datacontext;
using Infrostruckture.Migrations;
using Infrostruckture.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<ILibraryService,LibraryService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ScanIn(typeof(CreateBookTable).Assembly).For.Migrations());


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "ok"));
}
using var scope = app.Services.CreateScope();
var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
try
{
    runner.MigrateUp();
}
catch (Exception ex)
{
    Console.WriteLine($"Error applying migrations: {ex.Message}");
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();