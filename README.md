# Introdução
   Esta Solução contém 4 Projetos:
   
   1. [Autenticação] -> Responsável pelo controle de login do sistema
   2. [Dna.Client] -> Contém toda programação de interface e códigos de front-end;
   3. [Dna.Common] -> Código intermediário, de compartilhamento entre os projetos da Solução;
   4. [Dna.Server] -> Contém toda informação sobre banco de dados, do sistema;

# Getting Started
1.	Processo de Instalação/Inicialização
2.	Dependências
3.	Publicação

# Primeira execução

Siga estritamente a sequência abaixo:

## Instalação do AspNetCore:
  Verifique se está instalado o AspNetCore-2.1.1. Caso não esteja, baixe utilizando os links abaixo e instale.
    [AspNetCore-2.1.1] * Caso necessário
      <x64> https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-2.1.1-windows-x64-installer
      <x86> https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-2.1.1-windows-x86-installer

## Execução do migrations AspNetUsers:
  pelo terminal, na pasta: [./Autenticacao] execute os comandos, nesta sequência:
    -> dotnet tool restore
    -> dotnet ef database update -c ApplicationDbContext

## Execução do migrations da DNA:
  pelo terminal, na pasta: [./Dna.Server] execute os comandos, nesta sequência:
    -> dotnet tool restore
    -> dotnet ef database update -c DnaContext

# Processo de Instalação/Inicialização
## Configurações do Projeto:
   - Nas propriedades da solução (botão direito em cima da solução --Solution 'Dna'---)
     configure os projetos para serem inicializados:
       * Autenticação
       * Dna.Server
   
   - Execução os migrations no cmd:
    
    [./Dna.Server] 
    dotnet ef database update -c DnaContext

    [./Autenticacao]
    dotnet ef database update -c ApplicationDbContext
        <Obs: credenciais inicias estão em: /Dna.Server/appsettings.json/appsettings.Development>

## Dna.Client

- Execute os comandos no cmd

    1. npm install
    2. npm start

# Publicação

1. Solicitar acesso ao painel do Azure da DNA;
2. Já logado no Azure, acessar o site ao qual deseja obter perfil de publicação (ex.: dna-app-hom)
3. Nas opções superiores, clicar em "Obter Perfil de Publicação". 
4. No VisualStudio, clicar com o botão direito do mouse, sobre o projeto em questão (ex.: Dna.Server) e selecionar a opção 'PUBLISH'
5. Clicar em "New", selecionar a opção "Import Profile" e importe o arquivo baixado do Azure.


* Relação de Projetos/Azure:
=========================================================================
 AZURE                                  VisualStudio/Projeto            
=========================================================================
[dna-app] <Producao>                    [Dna.Server]
[dna-login] <Producao>                  [Autenticacao]
[dna-app-hom] <homolocacao>             [Dna.Server] 
[dna-auth-hom] <homolocacao>            [Autenticacao] 
=========================================================================

* Relação de Bases de Dados no Azure:
=========================================================================
[dna-app] <Producao>
[dna-app-hom-v2] <Homologação>
=========================================================================