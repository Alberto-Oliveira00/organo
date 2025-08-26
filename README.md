# Organo - Front + Back-End

![React](https://img.shields.io/badge/React-20232A?style=for-the-badge\&logo=react\&logoColor=61DAFB)
![.NET 8](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge\&logo=ef\&logoColor=white)

---

Este projeto nasceu como um **desafio pessoal**: durante meus estudos na **Alura** desenvolvi apenas o **front-end** da aplicação, mas senti falta de colocar em prática também o **back-end**.
Por isso, evoluí o projeto criando uma **API em .NET 8 com Entity Framework e SQL Server**, integrando-a ao **React**.

---

## ✨ Funcionalidades

### 🔹 Front-End

* Cadastro e listagem de **Colaboradores**.
* Cadastro e listagem de **Times**.
* Consumo da API em tempo real.
* Componentes reutilizáveis em React.

### 🔹 Back-End (API .NET 8 + EF Core)

* CRUD completo para **Times**.
* CRUD completo para **Colaboradores**.
* Persistência em **SQL Server**.
* Padrões de boas práticas (DTOs, Repositories, Unit of Work).

---

## 📦 Entregas da API

### Times

* `POST /api/times` → Criar novo time
* `GET /api/times` → Listar todos os times
* `GET /api/times/{id}` → Buscar time por ID
* `PUT /api/times/{id}` → Atualizar time
* `DELETE /api/times/{id}` → Remover time

### Colaboradores

* `POST /api/colaboradores` → Criar novo colaborador
* `GET /api/colaboradores` → Listar todos os colaboradores
* `GET /api/colaboradores/{id}` → Buscar colaborador por ID
* `PUT /api/colaboradores/{id}` → Atualizar colaborador
* `DELETE /api/colaboradores/{id}` → Remover colaborador

---

## 🛠️ Tecnologias Utilizadas

* **Front-End**: React, CSS Modules
* **Back-End**: ASP.NET Core 8, C#, Entity Framework Core
* **Banco de Dados**: SQL Server
* **Controle de versão**: Git + GitHub

---

## 🚀 Como rodar o projeto

### 🔹 Back-End

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/screensound.git

# Entre na pasta do back-end
cd screensound-backend

# Configure a connection string do SQL Server no appsettings.json

# Execute as migrations
dotnet ef database update

# Rode a API
dotnet run
```

A API ficará disponível em: `https://localhost:5001` (ou porta configurada).

### 🔹 Front-End

```bash
# Entre na pasta do front-end
cd screensound-frontend

# Instale as dependências
npm install

# Rode o projeto
npm start
```

O front estará disponível em: `http://localhost:3000`

