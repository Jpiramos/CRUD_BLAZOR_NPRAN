# Projeto CRUD em Blazor - Relacionamento Muitos-para-Muitos

Este projeto foi desenvolvido como parte da disciplina de Programação Orientada a Objetos da faculdade. Ele implementa um sistema CRUD utilizando Blazor para gerenciar médicos, pacientes e consultas, explorando o relacionamento muitos-para-muitos.

## Funcionalidades

- **Médicos**: Adicionar, editar, listar e excluir médicos.
- **Pacientes**: Adicionar, editar, listar e excluir pacientes.
- **Consultas**: Agendar consultas associando médicos a pacientes, editar, listar e cancelar consultas.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Models**: Contém as classes `Person`,`Medic`, `Patient` e `MedicalAppointment`.
- **Data**: Contém o contexto do banco de dados e as configurações de migração.
- **Pages**: Contém as páginas Razor que implementam as funcionalidades CRUD.
- **Shared**: Contém componentes compartilhados entre as páginas.

## Pré-requisitos

- [.NET 5 ou superior](https://dotnet.microsoft.com/download)
- [Visual Studio 2019 ou superior](https://visualstudio.microsoft.com/) com a carga de trabalho de desenvolvimento web.

## Como Configurar o Projeto

1. **Clone o repositório do GitHub:**

   ```bash
   git clone 
   cd seu-repositorio
Abra o projeto no Visual Studio:

Abra o Visual Studio e selecione "Abrir um projeto ou solução", navegando até o diretório onde você clonou o repositório.

Restaurar os pacotes NuGet:

No Visual Studio, vá para Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes e execute o seguinte comando:

powershell
Copiar código
Update-Database
Executar o projeto:

Pressione F5 ou clique em Executar no Visual Studio para iniciar o projeto.

Contribuição
Se você deseja contribuir com este projeto, siga os passos abaixo:

Faça um fork do repositório.
Crie uma branch para sua feature (git checkout -b feature/nova-feature).
Commit suas mudanças (git commit -am 'Adiciona nova feature').
Faça o push para a branch (git push origin feature/nova-feature).
Abra um Pull Request.
Licença
Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo LICENSE para mais detalhes.

