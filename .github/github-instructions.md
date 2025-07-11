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
- [ ] Visualização de seus próprios pedidos -> /Clientes/id/Pedidos

### 2. Pedido
- [ ] Criação de pedido pelo cliente autenticado
- [ ] Seleção de documentos a serem entregues -> String simbolizando
- [ ] Definição do endereço de entrega
- [ ] Registro automático da data e hora do pedido
- [ ] Associação do pedido a um cliente

### 3. Movimentação
- [ ] Atualização de status do pedido (ex: "Pendente", "Em Transporte", "Entregue")
- [ ] Registro de data/hora de cada mudança de status
  - -> UpdatedAt -> sempre que tiver movimentação registra o horário MAS sobrescreve o anterior
  - -> Entidade / objeto de movimentação que registra a transição de status e o horário / data
  - -> campos individuais pra cada movimentação PendenteAt, EmTransporteAt, EntregueAt
- [ ] Registro do responsável pela movimentação
  - -> modo de registrar um possível 'entregador' ou 'responsável' que não seja um cliente
    - Entra na hierarquia de cliente -> Usuário superclasse de Cliente e Funcionario

### 4. Financeiro -> /Financeiro
- [ ] Registro de valor associado a cada entrega
- [ ] Relatórios de totalização por período (mensal, semanal) -> /RelatorioPeriodoPorCliente/idCliente -> form -> valor
- [ ] Relatório por cliente com total de entregas e valores -> /RelatorioGeralPorCliente/idCliente

---

## 🛠️ Requisitos Não Funcionais
- [ ] Interface Web responsiva usando ASP.NET MVC
- [ ] Persistência de dados com Entity Framework
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
Este sistema servirá como ferramenta central para garantir o rastreamento eficiente de documentos sigilosos, com foco em controle, segurança e transparência para os clientes da XYZ.# 📦 Sistema de Entrega de Documentos Sigilosos - Especificação Técnica

## 🏢 Contexto do Negócio
A empresa **XYZ** é especializada no **transporte seguro de documentos confidenciais** entre empresas, órgãos públicos e pessoas físicas. O sistema deve controlar todo o ciclo de vida das entregas, desde o pedido até a confirmação de entrega, garantindo rastreabilidade completa e segurança dos dados.

**Tecnologias Base:** ASP.NET MVC Core + Entity Framework + SQL Server

---

## 🎯 Escopo e Objetivos
O sistema deve cobrir 4 módulos principais:
1. **Gestão de Usuários** (Clientes e Funcionários)
2. **Controle de Pedidos** (Solicitações de entrega)
3. **Rastreamento de Movimentações** (Status e histórico)
4. **Relatórios Financeiros** (Faturamento e análises)

---

## 👥 Perfis de Usuário e Hierarquia

### Hierarquia de Classes
### Cliente
- **Função:** Solicita entregas de documentos
- **Acesso:** Visualiza apenas seus próprios pedidos
- **Dados:** Nome, CPF/CNPJ, Endereço completo, Telefone, Email

### Funcionário/Entregador
- **Função:** Atualiza status dos pedidos durante transporte
- **Acesso:** Visualiza pedidos atribuídos a ele
- **Dados:** Nome, CPF, Cargo, Telefone, Email

---

## 🛠️ Entidades e Relacionamentos

### 1. Usuario (Tabela Base)
### 2. Cliente (Herda de Usuario)
### 3. Funcionario (Herda de Usuario)
### 4. Pedido
### 5. Movimentacao (Histórico de Status)
---

## 📊 Estados do Pedido (Enum)
---

## 🌐 Estrutura de Controllers e Rotas

### ClientesController
- `GET /Clientes` - Listar todos os clientes (apenas funcionários)
- `GET /Clientes/Create` - Formulário de cadastro
- `POST /Clientes/Create` - Processar cadastro
- `GET /Clientes/{id}/Edit` - Editar cliente
- `POST /Clientes/{id}/Edit` - Salvar alterações
- `GET /Clientes/{id}/Pedidos` - Histórico de pedidos do cliente

### PedidosController
- `GET /Pedidos` - Dashboard de pedidos
- `GET /Pedidos/Create` - Novo pedido (apenas clientes)
- `POST /Pedidos/Create` - Processar novo pedido
- `GET /Pedidos/{id}` - Detalhes do pedido
- `POST /Pedidos/{id}/AtualizarStatus` - Mudança de status

### MovimentacoesController
- `GET /Movimentacoes/{pedidoId}` - Histórico completo do pedido
- `POST /Movimentacoes/Create` - Registrar nova movimentação

### FinanceiroController
- `GET /Financeiro` - Dashboard financeiro
- `GET /Financeiro/RelatorioPeriodo` - Relatório por período
- `POST /Financeiro/RelatorioPeriodo` - Processar filtros
- `GET /Financeiro/RelatorioCliente/{clienteId}` - Relatório por cliente

---

## 📈 Regras de Negócio Específicas

### Fluxo de Status
1. **Pendente** → **Coletado** (funcionário confirma coleta)
2. **Coletado** → **Em Trânsito** (documento em rota)
3. **Em Trânsito** → **Entregue** (confirmação de entrega)
4. Qualquer status → **Cancelado** (apenas funcionários)

### Auditoria e Rastreamento
- Toda mudança de status deve registrar: data/hora, funcionário responsável, status anterior e novo
- Pedidos não podem ser excluídos, apenas cancelados
- Histórico de movimentações deve ser preservado indefinidamente

### Cálculos Financeiros
- Valor base por tipo de documento
- Valor adicional por distância (futuro)
- Relatórios devem considerar apenas pedidos com status "Entregue"

---

## 🔐 Considerações de Segurança
- Clientes só visualizam seus próprios dados
- Funcionários têm acesso amplo para operações
- Logs de auditoria para todas as operações críticas
- Validação rigorosa de CPF/CNPJ
- Proteção contra SQL Injection via Entity Framework

---

## 📱 Interface e UX
- **Responsiva:** Bootstrap 5 para compatibilidade mobile
- **Dashboard:** Widgets com resumos por status
- **Filtros:** Data, cliente, status, funcionário responsável
- **Paginação:** Para listas com muitos registros
- **Notificações:** Alertas para mudanças de status importantes

---

## 🚀 Implementação Técnica

### Estrutura do Projeto
### Padrões Recomendados
- **Repository Pattern** para acesso a dados
- **ViewModel** para transfer de dados para Views
- **Data Annotations** para validação
- **Dependency Injection** para services
- **AutoMapper** para mapeamento entre entidades