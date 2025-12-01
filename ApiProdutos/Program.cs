using ApiProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ProdutoService>();
builder.Services.AddSingleton<PedidoService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();