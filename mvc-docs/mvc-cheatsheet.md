# .NET CLI Cheat Sheet – ASP.NET Core MVC

## Comandos 

- **Criar uma aplicação ASP.NET Core MVC**:

```bash
    dotnet new mvc -n <ProjectName>
```

- **Compilar o projeto**:
```bash
    dotnet build
```
- **Executar o projeto**:
```bash
    dotnet run 
```
## Gerenciamento de Soluções:

- **Criar uma solução**:
```bash
    dotnet new sln -n <SolutionNme>
```
- **Adicionar um projeto à Solução**:
```bash
    dotnet sln add <ProjectName>
```
- **Remover um projeto da Solução**:
```bash
    dotnet sln remove <ProjectName>
```

## Gerenciamento de Pacotes:

O `NuGet` é o gerenciador de pacotes para a plataforma .NET

- **Restaurar pacotes NuGet**:
```bash
    dotnet restore 
```
- **Adicionar um pacote NuGet ao projeto**:
```bash
    dotnet add package <PackageName>
```
- **Remover um pacote NuGet do projeto**:
```bash
    dotnet remove package <PackageName>
```
- **Listar pacotes instalados no projeto**:
```bash
    dotnet list package
```

## Comandos do Entity Framework Core:

O `Entity Framework Core (EF Core)` é um ORM (Object-Relational Mapper) que permite que o desenvolvedor trabalhe com banco de dados usando objetos do .NET, abstraindo grande parte da complexidade das manipulações diretas de dados.


- **Instalar ferramentas do Entity Framework Core**:
```bash
    dotnet tool install --global dotnet-ef
```
- **Adicionar EF Core ao projeto**:

DataBaseName: `PostgreSQL`/`Sqlite`/`SqlServer`

```bash
    dotnet add package Microsoft.EntityFrameworkCore.<DataBaseName>
```
#### Criação e Gerenciamento de `migrations`:
As migrações são usadas para sincronizar o modelo do banco de dados com o modelo de classes que foi definido no código. As migrações ajudam a manter o banco de dados em conformidade à medida que você altera suas classes e o esquemas de dados.

- **Adicionar uma migração**:
Este comando cria um arquivo de migração baseado nas alterações feitas nas classes do modelo.
```bash
    dotnet ef migration add <MigrationName>
```

- **Remover a última migração**:
Caso queira reverter a última migração adicionada.
```bash
    dotnet ef migrations remove
```

- **Atualizar o banco de dados**:
Aplica todas as migrações pendentes ao banco de dados. Isso cria ou altera tabelas no banco de dados conforme definido no seu modelo de classes.
```bash
    dotnet ef database update
```
- **Reverter o banco de dados para uma migração específica**:
É possível especificar uma migração para reverter ou avançar o banco de dados para um estado particular.
```bash
    dotnet ef database update <MigrationName>
```
- **Gerar um script SQL a partir de uma ou mais migrações**:
Isso é útil para quando você não pode aplicar migrações diretamente no ambiente de produção, mas precisa gerar o SQL correspondente para execução manual.
```bash
    dotnet ef migrations script
```

- **Criar o banco de dados**:
o EF Core pode criar um banco de dados vazio com base no modelo definido.
```bash
    dotnet ed database update
```

- **Apagar o banco de dados**:
Em desenvolvimento, às vezes é útil remover o banco de dados.
```bash
    dotnet ef database drop
```
- **Vizualizar modelos e informações**:
Para verificar as configurações do EF Core no seu projeto, como o provedor de banco de dados em uso.
```bash
    dotnet ef dbcontext info
```
- **Listas migrações existentes**:
Mostra todas as migrações que foram criadas e estão no controle de versão do projeto.
```bash
    dotnet ef migrations list
```

## Executar o Servidor Kestrel

- **Especificar a porta para o servidor Kestrel**:
```bash
    dotnet run --urls "http://localhost:9999"
```

## Testes 

- **Criar um projeto de testes com xUnit.net**:
```bash
    dotnet new xunit -n <TestProjectName>
```
- **Adicionar referência ao projeto principal**:
```bash
    dotnet add <TestProjectName> reference <ProjectName>
```
- **Executar testes**:
```bash
    dotnet test
```

## Outros comandos úteis:

- **Atualizar pacotes NuGet**:
```bash
    dotnet add package <PackageName> --version <VersionNumber>
```
- **Listar templates disponíveis**:
```bash
    dotnet new --list
```
- **Verificar versão do SDK.NET**:
```bash
    dotnet --version
```
- **Listar versões do SDK instaladas**:
```bash
    dotnet --list-sdks
```
- **Listar versões do runtime instaladas**:
```bash
    dotnet --list-runtimes
```
