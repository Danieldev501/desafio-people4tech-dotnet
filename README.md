# DesafioPeople4Tech - API Simples

Este projeto é uma API mínima para gerenciar produtos e pedidos (feito em estilo simples, adequado para um candidato a estágio).

Pré-requisitos
- .NET 10 SDK instalado
- PowerShell (Windows)

Como compilar
```pwsh
cd "C:\Users\danio\Documents\DesafioPeople4Tech"
dotnet build DesafioPeople4Tech.sln
```

Como executar (modo simples)
```pwsh
# Inicia a API na porta 5000
dotnet run --project "C:\Users\danio\Documents\DesafioPeople4Tech\ApiProdutos\ApiProdutos.csproj" --urls "http://localhost:5000"
```

Exemplos de teste (PowerShell)
- Cadastrar um produto:
```pwsh
$body = @{ Nome='Caneta'; Descricao='Azul'; Preco=2.5; QuantidadeEmEstoque=5 } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/produtos' -Body $body -ContentType 'application/json'
```

- Listar produtos:
```pwsh
Invoke-RestMethod 'http://localhost:5000/api/produtos'
```

- Criar pedido (produto com Id = 1):
```pwsh
$pedido = @{ NomeCliente='João'; Itens=@(@{ ProdutoId=1; Quantidade=2 }) } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/pedidos' -Body $pedido -ContentType 'application/json'
```

- Criar pedido com estoque insuficiente (espera erro 400):
```pwsh
$pedido2 = @{ NomeCliente='Maria'; Itens=@(@{ ProdutoId=1; Quantidade=10 }) } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/pedidos' -Body $pedido2 -ContentType 'application/json'
```

Parar a API iniciada em background (se necessário)
```pwsh
# Para processos que iniciaram com dotnet run e estão nomedados ApiProdutos
Get-Process -Name ApiProdutos -ErrorAction SilentlyContinue | ForEach-Object { Stop-Process -Id $_.Id -Force }
```

Observações
- O código foi mantido simples e com inicializadores básicos para strings nos modelos (estilo iniciante).
- Caso queira que eu mantenha a API rodando enquanto eu executo mais testes automáticos, me avise.
