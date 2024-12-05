using KanzWay.DependencyConfiguration;
using KanzWay.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program
{

}