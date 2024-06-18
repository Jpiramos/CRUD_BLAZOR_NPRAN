# Projeto CRUD em Blazor - Relacionamento Muitos-para-Muitos

Este projeto foi desenvolvido como parte da disciplina de Programação Orientada a Objetos II da faculdade. Ele implementa um sistema CRUD utilizando Blazor para gerenciar médicos, pacientes e consultas, explorando o relacionamento muitos-para-muitos.

## Funcionalidades

- **Médicos**: Adicionar, listar e excluir médicos.
- **Pacientes**: Adicionar, listar e excluir pacientes.
- **Consultas**: Agendar consultas associando médicos a pacientes, listar e cancelar consultas.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Models**: Contém as classes `Person`,`Doctor`, `Patient` e `MedicalAppointment`.
- **DTO**: Contém as classes: `DoctorDTO`, `PatientDTO` e `MedicalAppointmentDTO`
- **Data**: Contém o contexto do banco de dados e as configurações de migração.
- **Pages**: Contém as páginas Razor que implementam as funcionalidades CRUD.
- **Shared**: Contém componentes compartilhados entre as páginas.
<p align="center">
  <img src="https://github.com/Jpiramos/CRUD_BLAZOR_NPRAN_POO2/assets/102618195/1938210b-d0e4-4f2e-a102-a5b1db895a87" alt="Descrição da imagem" style="border-radius: 50%;">
</p>


## Pré-requisitos

- [.NET 5 ou superior](https://dotnet.microsoft.com/download)
- [Visual Studio 2019 ou superior](https://visualstudio.microsoft.com/)
-  [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)


## Como Configurar o Projeto

1. **Clone o repositório do GitHub:**

Abra o Terminal e execute o seguinte comando na pasta destino: 
   ```
   git clone https://github.com/Jpiramos/CRUD_BLAZOR_NPRAN_POO2.git
   ```
   
Abra o Visual Studio e selecione "Abrir um projeto ou solução", navegando até o diretório onde você clonou o repositório.

2. **Restaurar os pacotes NuGet:**

No Visual Studio, vá para Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes e execute o seguinte comando:

   ```
   Update-Database
   ```
3. **Executar o projeto:**

Pressione F5 ou clique em Executar no Visual Studio para iniciar o projeto.
______________________________________________________________________________________________________________________
Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo LICENSE para mais detalhes.

*Desenvolvido por João Pedro Ramos, Caio Vieira e Lucas Andrade.*

