using GameStoreFrontend.Clients;
using GameStoreFrontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents(); //Adicionando interactive server side rendering

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
    throw new Exception("GameStoreApiUrl is not set");  //Caso o url esteja recebendo nulo

builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();  //Adicionando interactive server side rendering

app.Run();
