# TaskMaster.API – Backend em ASP.NET Core + PostgreSQL

## Pré-requisitos

- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- Ferramenta Entity Framework CLI:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

##  Como executar o backend

### 1. Clone o repositório e entre na pasta do projeto:

```bash
git clone https://github.com/seu-usuario/TaskMaster.API.git
cd TaskMaster.API
```

### 2. Configure o banco de dados

No arquivo `appsettings.json`, atualize a connection string com os dados do seu PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=taskmasterdb;Username=postgres;Password=senha"
}
```

### 3. Crie o banco de dados (caso não exista ainda)

Você pode rodar o script `taskmasterdb.sql` ou criar direto no PostgreSQL:

```sql
CREATE DATABASE taskmasterdb;
```

### 4. Execute as migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Rode a API

```bash
dotnet run
```

A API estará disponível em: `https://localhost:7280(ou a porta configurada na database postgres)`

---

## 🧪 Testar no Postman

Importe a collection `TaskMaster_API.postman_collection.json` (caso esteja disponível) para testar os endpoints:

- `GET /api/tasks`
- `POST /api/tasks`
- `PUT /api/tasks/{id}`
- `DELETE /api/tasks/{id}`

---

## 📁 Estrutura do Projeto

```
TaskMaster.API/
│
├── Controllers/
│   └── TasksController.cs
│
├── Models/
│   └── TaskItem.cs
│
├── Data/
│   └── TaskContext.cs
│
├── Program.cs
├── appsettings.json
└── TaskMaster.API.csproj
```
