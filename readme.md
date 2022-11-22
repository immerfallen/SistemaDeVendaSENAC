# Projeto Integrador Criação de Minimum Viable Product - SENAC EAD

## Integrantes do grupo: Bruno Luiz Paguetti Roque, Darney Aguera da Costa, Gustavo Albuquerque Eidt, Maro de Melo, Rafael Carlos de Souza

### Instalando a aplicação

Para fazer a instalação do projeto é necessário seguir alguns passo descrito abaixo:
- Em um diretório em seu computador, abra o terminal e digite o seguinte comando: `git clone https://github.com/immerfallen/SistemaDeVendaSENAC.git`
- Após isso será necessário instalar o SQL Server, poderá baixá-lo na seguinte URL: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
- Após o termino da instalação clique em `Iniciar` para rodar o SQL Server
- Agora iremos instalar o SQL Server Management Studio (SSMS), o download poderá ser realizado na seguinte URL: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
- Após instalado abra o SQL Server Management Studio (SSMS), utilize o seguinte Nome do Servidor: `localhost`

### Instalando o .Net

- Clique no link e instale o .Net 2.1: https://dotnet.microsoft.com/en-us/download/dotnet/2.1
- Agora clique no link e instale o .Net SDK: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-2.1.818-windows-x86-installer
- Após ter realizado a instalação, abra o terminal e digite o seguinte comando para ver se a instalação está correta `dotnet --version`
- Caso não esteja correta será necessário inserir nas váriaveis de ambiente do Windows. Selecione a variável `path` e insira o seguinte caminho `C:\Program Files\dotnet`. Salve e feche a janela.

### Rodando o .NET
- Abra o terminal o digite o seguinte comando `cd SistemaDeVenda.Server` para acessar o diretório do back-end e depois `dotnet build` para buildar
- Após digite `dotnet ef database update` para atualizar o Banco de Dados
- Para rodar o .NET digite `dotnet run`
- Provavelmente irá rodar na porta 5000, clique na seguinte URL para verificar as API's: http://localhost:5000/swagger/index.html

### Rodando a interface da aplicação
- Abra o terminal e digite `cd sistema-de-venda-front` para acessar o diretório da interface
- Após isso digite `npm i` para instalar as dependências do Angular
- Após a instalação digite `npm start` para iniciar a aplicação, ela irá abrir automáticamente na URL: http://localhost:4200/
- Os usuários utilizados foram `rafael@sdv.com`, `jose@sdv.com` e `manoel@sdv.com`, todos com a senha `1234`.