# 💸 CashFlow API

Esta API, desenvolvida com **.NET 8**, segue os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução estruturada e eficaz no gerenciamento de **despesas pessoais**.

O principal objetivo é permitir que os usuários registrem suas despesas de forma detalhada, incluindo:

- Título  
- Data e hora  
- Descrição  
- Valor  
- Tipo de pagamento  

Os dados são armazenados com segurança em um banco de dados **MySQL**.

A arquitetura da API é baseada em REST, utilizando métodos HTTP padrão para uma comunicação eficiente e simplificada. Além disso, conta com documentação interativa via **Swagger**, facilitando a exploração e o teste dos endpoints por desenvolvedores.


![image](https://github.com/user-attachments/assets/492e6360-13b4-47cc-a043-e939abe419c4)


---

## 🧰 Tecnologias e Pacotes Utilizados

- **AutoMapper**: Mapeamento entre objetos de domínio e DTOs (requisição/resposta), reduzindo a repetição de código.
- **FluentAssertions**: Escrita de testes unitários com asserções claras e legíveis.
- **FluentValidation**: Validações nas classes de requisição de forma simples e intuitiva.
- **Entity Framework Core**: ORM para interação com o banco de dados utilizando objetos .NET.
- **Swagger (Swashbuckle)**: Interface gráfica interativa para teste e visualização dos endpoints.

---

## 🚀 Funcionalidades

- ✅ **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- ✅ **Testes de Unidade**: Testes com FluentAssertions para garantir a qualidade e funcionalidade da aplicação.
- ✅ **Geração de Relatórios**: Exportação de relatórios detalhados e em Excel, oferecendo uma análise visual eficaz das despesas.
- ✅ **API REST com Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

---

## 🛠️ Como Começar

### ✅ Pré-requisitos

- Visual Studio 2022+ ou Visual Studio Code  
- Windows 10+, Linux ou macOS com **.NET SDK** instalado  
- **MySQL Server**

### ⚙️ Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/CaioFurtadoo/CashFlow.git
