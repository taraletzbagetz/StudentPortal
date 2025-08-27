using StudentPortal.Empty.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, MockEmailService>();

var app = builder.Build();

if (builder.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

//app.MapGet("/", () => "Mars!");

//app.Run(async ctx =>
//{
//    //await ctx.Response.WriteAsync("Welcome to Earth!");
//    await ctx.Response.WriteAsync("<html><head></head><body><h1>Test HTML</h1></body></html>");
//});

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
