
# 📌 CRUD-ANGULAR-CSHARP-Back-end

Este é o backend para um sistema de CRUD desenvolvido em **C#** com **.NET**, integrado com um banco de dados **SQL Server**. O projeto fornece uma API para ser consumida pelo frontend desenvolvido em **Angular**.

----------

## 📋 Requisitos

Antes de iniciar, certifique-se de que possui os seguintes softwares instalados na sua máquina:

-   [**Visual Studio 2022**](https://visualstudio.microsoft.com/pt-br/downloads/) (recomendado)
-   [**.NET 6 ou superior**](https://dotnet.microsoft.com/download/dotnet)
-   [**SQL Server**](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
-   [**Git**](https://git-scm.com/) (para versionamento do código)

----------

## 🚀 Como Rodar o Projeto

### 1️⃣ Clonar o Repositório

Abra o terminal e execute o comando

`git clone https://github.com/EmanoelProjects/CRUD-ANGULAR-CSHARP-Back-end.git` 

Depois, entre na pasta do projeto:

`cd CRUD-ANGULAR-CSHARP-Back-end` 

----------

### 2️⃣ Abrir o Projeto no **Visual Studio 2022**

1.  Abra o **Visual Studio 2022**.
2.  Clique em **"Abrir um projeto ou solução"**.
3.  Navegue até a pasta do projeto e selecione o arquivo **`ControleDeFinancas.Backend.sln`**.

----------

### 3️⃣ Configurar a String de Conexão

No **Visual Studio 2022**, abra o arquivo **`appsettings.json`** e edite a seção `"ConnectionStrings"` para apontar para seu banco de dados SQL Server:



`"ConnectionStrings": {
  "sqlServer": "Server=SEU_SERVIDOR; Database=Financas-api; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True"
}` 

📌 **O que alterar?**

-   Substitua **`SEU_SERVIDOR`** pelo nome do seu servidor SQL.
    -   Exemplo: `localhost`, `DESKTOP-123ABC`,  etc.
-   O banco de dados (`Financas-api`) será criado automaticamente pelo Entity Framework ao rodar as migrações.

----------

### 4️⃣ Aplicar Migrações e Criar o Banco de Dados

No **Visual Studio 2022**, abra o **Gerenciador de Pacotes NuGet**:

1.  Vá em **Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes**.
2.  No console, execute o seguinte comando:

`Update-Database` 

Se necessário, instale a ferramenta `EF Core` com:

`dotnet tool install --global dotnet-ef` 

----------

### 5️⃣ Rodando o Backend

1.  No **Visual Studio 2022**, clique na **seta verde** no topo da interface para iniciar a API.
    
2.  O backend iniciará 
----------

## 📡 Endpoints da API

Aqui estão alguns dos principais endpoints disponíveis no backend:


`GET`

`/api/usuarios`

Retorna todos os usuários

`GET`

`/api/usuarios/{id}`

Retorna um usuário específico

`POST`

`/api/usuarios`

Cria um novo usuário

`PUT`

`/api/usuarios/{id}`

Atualiza um usuário existente

`DELETE`

`/api/usuarios/{id}`

Remove um usuário do sistema

🔹 Para testar os endpoints, utilize o próprio **Swagger** (`https://localhost:7129/swagger/index.html`) ou ferramentas como **Postman** e **Insomnia**.

----------

## 🛠 Tecnologias Utilizadas

-   **C#** e **.NET 6**
-   **SQL Server**
-   **Entity Framework Core**
-   **Swagger para documentação da API**
-   **Visual Studio 2022**

