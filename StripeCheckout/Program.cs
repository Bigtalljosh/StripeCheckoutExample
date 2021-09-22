using StripeCheckout.Data;
using StripeCheckout.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.WebHost.ConfigureServices((hostContext, services) =>
{
    StripeCheckout.StripeConfig config = new();
    hostContext.Configuration.GetSection("Stripe").Bind(config);
    services.AddSingleton(config);    
    services.AddTransient<IStripeCheckoutSessionService, StripeCheckoutSessionService>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();