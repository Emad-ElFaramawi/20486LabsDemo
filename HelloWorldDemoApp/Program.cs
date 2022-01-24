var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseStaticFiles();

//app.Map("/Map", (map) =>
//{
//    map.Run(async (context) =>
//    {
//        await context.Response.WriteAsync("Run middleware inside of map middleware");
//    });
//});



//app.UseRouting();
//app.MapGet("/emad", () => "hello from map get");

app.Use(async (context, next) =>
{

    if (context.Request.Query.ContainsKey("id"))
    {
        await context.Response.WriteAsync($"The ID in the Query string is: {context.Request.Query["id"]} ");

    }
    await context.Response.WriteAsync($"The path is: {context.Request.Path.Value}");
    await next(context);
    //else
    //{
    //    await next(context);
    //}
});



app.Run(async (context) =>
{
    await context.Response.WriteAsync("Inside run middleware");
});


app.Run();
