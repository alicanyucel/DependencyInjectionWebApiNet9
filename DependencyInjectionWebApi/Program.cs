using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Test>();
builder.Services.AddTransient<Test2>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//minimal api
app.MapGet("test", (Test test,Test2 test2) =>
{
  //  Test test = new();
    var id = test.Id;
  //  Test2 test2 = new Test2(test); // service registeration
    test2.Method2();
    // other process
    return Results.Ok("HELLO WORLD");
});
app.MapGet("gb", () =>
{
    GC.Collect();//KULLANILMAYAN SEYELRÝ TEMÝZLE
    GC.WaitForPendingFinalizers();
    GC.Collect();
    return Results.Ok("Ok");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public class Test2
{
    Test _test;
    public Test2(Test test)
    {
        _test = test;
    }
    public void Method2()
    {
        Test test = new();
        var id = test.Id;
    }
}
public class Test
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Calculate()
    {
        return 5;
    }
}