dotnet run --project "C:\Users\danio\Documents\DesafioPeople4Tech\ApiProdutos\ApiProdutos.csproj" --urls "http://localhost:5000"
# DesafioPeople4Tech - API 

Este projeto é uma API bem básica pra gerenciar produtos e pedidos.

Coisas importantes:
- Precisa do .NET 10 SDK instalado.
- Use PowerShell no Windows pra rodar os exemplos abaixo.

Como compilar (rápido)
```pwsh
cd "C:\Users\danio\Documents\DesafioPeople4Tech"
dotnet build DesafioPeople4Tech.sln
```

Como executar (do jeito mais simples)
```pwsh
# abre a API na porta 5000
dotnet run --project "C:\Users\danio\Documents\DesafioPeople4Tech\ApiProdutos\ApiProdutos.csproj" --urls "http://localhost:5000"
```

Como testar (exemplos em PowerShell)

- Cadastrar um produto
```pwsh
$body = @{ Nome='Caneta'; Descricao='Azul'; Preco=2.5; QuantidadeEmEstoque=5 } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/produtos' -Body $body -ContentType 'application/json'
```

- Listar produtos
```pwsh
Invoke-RestMethod 'http://localhost:5000/api/produtos'
```

- Criar um pedido (supondo produto Id = 1)
```pwsh
$pedido = @{ NomeCliente='João'; Itens=@(@{ ProdutoId=1; Quantidade=2 }) } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/pedidos' -Body $pedido -ContentType 'application/json'
```

- Criar pedido com estoque insuficiente (vai dar erro)
```pwsh
$pedido2 = @{ NomeCliente='Maria'; Itens=@(@{ ProdutoId=1; Quantidade=10 }) } | ConvertTo-Json
Invoke-RestMethod -Method Post -Uri 'http://localhost:5000/api/pedidos' -Body $pedido2 -ContentType 'application/json'
```

Parar a API (se abriu em background)
```pwsh
Get-Process -Name ApiProdutos -ErrorAction SilentlyContinue | ForEach-Object { Stop-Process -Id $_.Id -Force }
```


-dados ficam em memória, sem banco.
- Validações mínimas, é pra mostrar funcionamento básico.
