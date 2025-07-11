# 📦 Levantamento de Requisitos - Mini-Projeto MVC C# com Entity Framework

## 🏢 Visão Geral
A empresa **XYZ** atua no setor de **entregas de documentos sigilosos**. Foi solicitado o desenvolvimento de um sistema baseado em **MVC C#** com **Entity Framework** para controle de pedidos, movimentações e entregas físicas destes documentos.

---

## 🎯 Objetivo do Sistema
- Permitir o **cadastro de clientes**
- Registrar e acompanhar **pedidos de entrega** feitos pelos clientes
- Gerenciar **status** dos pedidos (e.g. Pendente, Em Trânsito, Entregue)
- Controlar a **movimentação física** dos documentos
- **Totalizar o valor de entregas** por cliente em um determinado período

---

## 🧱 Requisitos Funcionais

### 1. Cliente
- [ ] Cadastro de cliente (Nome, CPF/CNPJ, Endereço, Contato)
- [ ] Edição e exclusão de dados cadastrais
- [ ] Autenticação para acesso ao sistema
- [ ] Visualização de seus próprios pedidos

### 2. Pedido
- [ ] Criação de pedido pelo cliente autenticado
- [ ] Seleção de documentos a serem entregues
- [ ] Definição do endereço de entrega
- [ ] Registro automático da data e hora do pedido
- [ ] Associação do pedido a um cliente

### 3. Movimentação
- [ ] Atualização de status do pedido (ex: "Pendente", "Em Transporte", "Entregue")
- [ ] Registro de data/hora de cada mudança de status
- [ ] Registro do responsável pela movimentação

### 4. Financeiro
- [ ] Registro de valor associado a cada entrega
- [ ] Relatórios de totalização por período (mensal, semanal)
- [ ] Relatório por cliente com total de entregas e valores

---

## 🛠️ Requisitos Não Funcionais
- [ ] Interface Web responsiva usando ASP.NET MVC
- [ ] Persistência de dados com Entity Framework
- [ ] Controle de autenticação via Identity ou similar
- [ ] Boas práticas de segurança (criptografia de dados sensíveis)
- [ ] Facilidade para auditoria e rastreamento de movimentações

---

## 🗃️ Estrutura de Tabelas (Modelo Inicial)
| Tabela       | Atributos Principais                                                |
|--------------|---------------------------------------------------------------------|
| Clientes     | Id, Nome, CPF/CNPJ, Endereço, Telefone                              |
| Pedidos      | Id, ClienteId, DataPedido, EndereçoEntrega, Status, Valor           |
| Movimentacoes| Id, PedidoId, DataHora, NovoStatus, Responsavel                     |

---

## 📈 Relatórios Esperados
- Total de pedidos entregues por período
- Status atual dos pedidos em tempo real
- Total financeiro por cliente
- Movimentação detalhada por pedido

---

## 🚀 Considerações
Este sistema servirá como ferramenta central para garantir o rastreamento eficiente de documentos sigilosos, com foco em controle, segurança e transparência para os clientes da XYZ.
 