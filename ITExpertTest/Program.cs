using ITExpertTest.Contexts;
using ITExpertTest.Interfaces;
using ITExpertTest.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using NLog.Web;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgesConnection")));
    builder.Services.AddScoped<ITodoRepository, TodoRepository>();
    builder.Services.AddScoped<ICommentaryRepository, CommentaryRepository>();

    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

