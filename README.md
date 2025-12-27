# 📦 Back Point API

API desenvolvida em ASP.NET Core Web API com documentação interativa via Swagger (OpenAPI).

---

## 🚀 Tecnologias Utilizadas

- .NET 10 (Preview) (compatível com .NET 8)
- ASP.NET Core Web API
- Swagger (Swashbuckle)
- Docker e Docker Compose
- Banco de Dados via Container (PostgreSQL, MySQL ou SQL Server)

---

## 📂 Estrutura do Projeto

back_point/
Controllers/
Models/
Services/
Data/
Program.cs
appsettings.json
docker-compose.yml
back_point.csproj

---

## ⚙️ Pré-requisitos

Antes de começar, você vai precisar ter instalado:

- .NET SDK 8 ou superior
- Docker
- Docker Compose
- Git

---

## 📥 Instalação

Clone o repositório:
```bash
git clone https://github.com/seu-usuario/back_point.git  
cd back_point
```
Restaure as dependências:
```bash
dotnet restore
```
---

## 🐳 Subindo o Banco de Dados com Docker

Antes de rodar a API, suba o container do banco de dados:
```bash
docker compose up -d
```

Esse comando irá:
- Criar o container do banco
- Expor a porta configurada no docker-compose.yml
- Manter os dados persistidos (se houver volume)

Para parar o container:

docker compose down

---

## ▶️ Executando a aplicação

Após subir o banco:

dotnet run

A API será iniciada em:

http://localhost:5258

---

## 📘 Documentação da API (Swagger)

A documentação interativa da API está disponível via Swagger.

Acesse no navegador:

http://localhost:5258/swagger

Funcionalidades do Swagger:
- Visualização de todos os endpoints
- Testes diretos via navegador
- Modelos de request e response
- Validação automática de parâmetros

---

## 🛠️ Configuração do Swagger

Configuração no Program.cs:

builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();

Pipeline:

if (app.Environment.IsDevelopment())  
{  
  app.UseSwagger();  
  app.UseSwaggerUI();  
}

---

## 🧪 Testes

Os endpoints podem ser testados utilizando:
- Swagger UI
- Postman
- Insomnia

---

## 🏗️ Build do Projeto

dotnet build

---

## 📄 Licença

Este projeto está sob a licença MIT.

---

## 👨‍💻 Autor

José Nailton Andrade Santos Junior  
Belo Jardim - PE  
Email: juniorborges.bj@gmail.com  
LinkedIn: https://www.linkedin.com/in/nailtonjr/  
GitHub: https://github.com/Naillton

---

## ⭐ Próximos Passos

- Integração completa Swagger + JWT  
- Migrations automáticas no startup  
- Dockerização da API  
- CI/CD  

```bash
git clone https://github.com/seu-usuario/back_point.git
cd back_point
```
