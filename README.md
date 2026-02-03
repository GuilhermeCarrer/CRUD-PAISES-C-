# 🌎 CRUD de Países - C# & SQL Server

Este é um mini sistema de Gerenciamento de Países desenvolvido em **C# (Windows Forms)** utilizando o **SQL Server**. 

## 🚀 Funcionalidades

- **Cadastrar:** Adiciona novos países (Código, Nome, População e Área).
- **Consultar:** Busca informações detalhadas através do código do país.
- **Atualizar:** Permite a edição de dados de registros já existentes.
- **Excluir:** Remove registros do banco de dados com confirmação de segurança.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (.NET Framework)
* **Interface:** Windows Forms (WinForms)
* **Banco de Dados:** SQL Server

---

## 📋 Pré-requisitos

- Windows
- Visual Studio
- SQL Server
- SQL Server Management Studio (SSMS)

### 1. Preparar o Banco de Dados
Abra o seu **SQL Server Management Studio (SSMS)** e execute o script abaixo para criar a estrutura necessária:

```sql
CREATE DATABASE crudpaises;
GO

USE crudpaises;
GO

CREATE TABLE paises (
    id_pais int not null primary key IDENTITY(1,1),
    cod_pais int,
    nome varchar(50),
    populacao int,
    area_total decimal(18, 2)
);

```
## 📦 Clonando e Executando o Projeto

- Clone este repositório:
- Abra o arquivo `.sln` no **Visual Studio**.
- Verifique a **string de conexão** com o **SQL Server**.
- Execute o projeto.





