using HomBase.Client.Components;
using HomBase.Client.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register PropertyService for making API calls
builder.Services.AddHttpClient<PropertyService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7299/"); // Adjust to match your HomBaseAPI URL
});

// Enable CORS (Blazor calls external APIs)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Enable CORS
app.UseCors("AllowAll");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
