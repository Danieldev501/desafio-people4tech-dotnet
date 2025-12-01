using ApiProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers
builder.Services.AddControllers();

// Registra serviços como singletons
builder.Services.AddSingleton<ProdutoService>();
builder.Services.AddSingleton<PedidoService>();

var app = builder.Build();

// Configura o pipeline HTTP
app.UseHttpsRedirection();
app.MapControllers();

app.Run();