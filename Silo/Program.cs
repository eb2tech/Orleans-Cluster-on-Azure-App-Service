// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License.

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("shoppingcart-redis");
builder.UseOrleans();

var services = builder.Services;
services.AddMudServices();
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddHttpContextAccessor();
services.AddSingleton<ShoppingCartService>();
services.AddSingleton<InventoryService>();
services.AddSingleton<ProductService>();
services.AddScoped<ComponentStateChangedObserver>();
services.AddSingleton<ToastService>();
services.AddLocalStorageServices();
services.AddHostedService<ProductStoreSeeder>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
await app.RunAsync();
