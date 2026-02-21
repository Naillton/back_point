# Back Point API

API backend desenvolvida em **ASP.NET Core** com foco em controle de pontos/registro de atividades, autenticação via **JWT**, arquitetura em camadas e boas práticas de organização de código.

> ⚠️ **Observação**: as migrations do Entity Framework **não fazem parte do repositório**. Elas devem ser geradas localmente conforme instruções abaixo.

---

## 🧠 Visão Geral do Projeto

O **Back Point** é uma API REST que gerencia:

* Empresas
* Usuários
* Pontos (registros)

A aplicação foi construída seguindo princípios como **separação de responsabilidades**, **injeção de dependência** e **camada de serviços**, tornando o projeto escalável e fácil de manter.

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```
Controllers  -> Camada de entrada (HTTP)
Services     -> Regras de negócio
Repositories -> Acesso a dados
DTOs         -> Objetos de transferência
Models       -> Entidades de domínio
Interfaces   -> Contratos
Validation   -> Validações de entrada
```

---

## 🛠️ Tecnologias Utilizadas

* .NET 8 / .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* JWT (JSON Web Token)
* BCrypt / Hash de senha
* Docker Compose
* SQL Server (ou outro provider EF Core)

---

## 🔐 Autenticação e Segurança

* Autenticação baseada em **JWT**
* Senhas armazenadas utilizando **hash seguro**
* Tokens gerados via `TokenService`
* Controle de acesso por middleware de autenticação

---

## 📁 Estrutura de Pastas

```
back_point/
│
├── Controllers/
├── Services/
├── Repository/
├── Models/
├── DTO/
├── Interfaces/
├── Validation/
├── Properties/
├── Program.cs
├── appsettings.json
├── docker-compose.yml
```

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

* .NET SDK instalado
* Banco de dados configurado
* Docker (opcional)

### Passos

1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/back_point.git
```

2. Configure o banco de dados no `appsettings.json`

3. Gere as migrations localmente

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Execute o projeto

```bash
dotnet run
```

5. Acesse a API

```
http://localhost:5000
```

---

## 📌 Endpoints Principais

### Empresa

* Criar empresa
* Login de empresa

### Usuário

* Cadastro de usuário
* Retorno de dados do usuário

### Ponto

* Criar registro de ponto
* Listar pontos

(Ver controllers para detalhes completos)

---

## 🧪 Testes

Os endpoints podem ser testados via:

* Swagger
* Postman
* Arquivo `back_point.http`

---

## 📦 Docker

O projeto conta com `docker-compose.yml` para facilitar a execução do ambiente.

```bash
docker-compose up -d
```

---

## ✅ Boas Práticas Aplicadas

* Injeção de dependência
* DTOs para evitar exposição de entidades
* Camada de validação
* Separação clara de responsabilidades
* Código organizado e extensível

---

## 📄 Licença

Este projeto é de uso educacional e demonstrativo.

---

## 👨‍💻 Autor

Desenvolvido por **Nailton Junior** 🚀

Email: **nailton_junior@protonmail.com**

LinkedIn: **https://www.linkedin.com/in/nailtonjr/**

Projeto com foco em aprendizado, boas práticas e portfólio profissional.
