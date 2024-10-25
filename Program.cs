
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // Configure the database context
// builder.Services.AddDbContext<AppDbContext>(options =>
// options.UseMySql("Server=localhost;Database=social_media;User=root;Password=root123;", 
//     new MySqlServerVersion(new Version(8, 0, 21))));


// var app = builder.Build();

// app.UseRouting();
// app.MapGet("/products", async (AppDbContext db) =>
// {
//     return await db.Products.ToListAsync();
// });

// app.MapPost("/products", async (AppDbContext db, Product1 product) =>
// {
//     db.Products.Add(product);
//     await db.SaveChangesAsync();
//     return Results.Created($"/products/{product.Id}", product);
// });
// app.Run();


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql("Server=localhost;Database=social_media;User=root;Password=root123;", 
        new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddControllers();

var app = builder.Build();

// Test the database connection
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        // Attempt to connect to the database
        await dbContext.Database.EnsureCreatedAsync();
        Console.WriteLine("Database connection successful!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
    }
}

app.UseRouting(); 
app.MapControllers(); 
 app.Run();
// app.MapGet("/products", async (AppDbContext db) =>
// {
//     return await db.Products.ToListAsync();
// });

// app.MapPost("/products", async (AppDbContext db, Product1 product) =>
// {
//     db.Products.Add(product);
//     await db.SaveChangesAsync();
//     return Results.Created($"/products/{product.Id}", product);
// });






















































// CRUD Operations:

// GET /api/products: Retrieves a list of all products.
// GET /api/products/{id}: Retrieves a specific product by ID.
// POST /api/products: Creates a new product.
// PUT /api/products/{id}: Updates an existing product by ID.
// DELETE /api/products/{id}: Deletes a product by ID.
