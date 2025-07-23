using Papu.Server.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

string strUrl = Environment.GetEnvironmentVariable("SUPABASE_PAPO_URL");
string strKey = Environment.GetEnvironmentVariable("SUPABASE_PAPO_KEY");

await ClientDB.Instance.InitializeAsync(strUrl, strKey);

builder.Services.AddSingleton(ClientDB.Instance.Client);

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
