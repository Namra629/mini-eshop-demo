var builder = WebApplication.CreateBuilder(args);

//
// ==========================
// SERVICES
// ==========================
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
// CORS (IMPORTANT for Angular)
//
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

//
// ==========================
// MIDDLEWARE PIPELINE
// ==========================

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS BEFORE endpoints
app.UseCors("AllowAll");

//
// ==========================
// IN-MEMORY DATA STORE
// ==========================

var products = new List<object>
{
    new { Id = 1, Name = "Laptop", Price = 900 },
    new { Id = 2, Name = "Phone", Price = 500 },
    new { Id = 3, Name = "Headphones", Price = 150 },
    new { Id = 4, Name = "Keyboard", Price = 80 }
};

var orders = new List<object>();

//
// ==========================
// APIs
// ==========================

// GET ALL PRODUCTS
app.MapGet("/api/products", () =>
{
    return Results.Ok(products);
});

// GET PRODUCT BY ID
app.MapGet("/api/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p =>
        (int)p.GetType().GetProperty("Id")!.GetValue(p)! == id);

    return product is not null
        ? Results.Ok(product)
        : Results.NotFound();
});

// CREATE ORDER (BUY BUTTON)
app.MapPost("/api/orders", (object product) =>
{
    var order = new
    {
        OrderId = Guid.NewGuid(),
        Product = product,
        Status = "Created",
        CreatedAt = DateTime.UtcNow
    };

    orders.Add(order);

    return Results.Ok(new
    {
        message = "Order placed successfully",
        order
    });
});

app.Run("http://0.0.0.0:5000");
