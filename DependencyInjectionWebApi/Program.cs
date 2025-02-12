var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("test", () =>
{
    Test test = new();
    var result = test.Calculate();
    // other process
    return "HELLO WORLD";
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
class Test
{
    public string Name { get; set; }
    public int Calculate()
    {
        return 5;
    }
}