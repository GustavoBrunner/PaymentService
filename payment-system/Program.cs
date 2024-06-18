using Microsoft.EntityFrameworkCore;
using payment_system.Entities.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString(nameof(TransactionsDbContext));

builder.Services.AddDbContext<TransactionsDbContext>(options => {
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddHttpClient("bank-mock", c => {
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:BankMock"]);
});
// .ConfigurePrimaryHttpMessageHandler(() =>
// {
//     var handler = new HttpClientHandler();
//     handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
//     return handler;
// });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.UseAuthorization();


app.MapControllers();



app.Run();
