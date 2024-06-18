using Microsoft.EntityFrameworkCore;
using user_api.Entities.Db;
using user_api.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("payment-system", c => {
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:TransactionSystem"]);
});
// .ConfigurePrimaryHttpMessageHandler(() =>
// {
//     var handler = new HttpClientHandler();
//     handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
//     return handler;
// });

var connectionString = builder.Configuration.GetConnectionString(nameof(UserDbContext));

builder.Services.AddDbContext<UserDbContext>(options => {
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
