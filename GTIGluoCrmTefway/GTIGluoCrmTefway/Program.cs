using GTIGluoCrmTefway.InfraEsctruture.Context;
using GTIGluoCrmTefway.IoC.Options;
using GTIGluoCrmTefway.Service.InjectDependencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<APIOption>(builder.Configuration.GetSection("APIs"));
builder.Services.AddServices(builder.Configuration);
builder.Services.AddRepositorys(builder.Configuration);


builder.Services.AddDbContext<DBContextSQL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
