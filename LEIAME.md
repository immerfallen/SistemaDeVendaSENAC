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

# Processo de Instalação/Inicialização
## Configurações do Projeto:
   - Nas propriedades da solução (botão direito em cima da solução --Solution 'Dna'---)
     configure os projetos para serem inicializados:
       * Autenticação
       * Dna.Server
   
   - Execute os migrations no cmd:
    
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