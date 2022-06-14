# FastTech


## Empresa de vendas FASTTECH
A empresa FastTech precisa de uma consultoria que dedsenvolva um sistema de gestão de vendas para controlar melhor todo o fluxo da sua empresa.

### 01 - Ações comuns

- Todas as Entities devem ter um CRUD.
- As Entities não podem ser excluídas, apenas desabilitadas.

### 02 - Controle de vendas

### Vendedor

- O vendedor pode obter relatórios por data das suas vendas.
- O vendedor pode adicionar/cadastrar uma venda.
- O vendedo pode editar uma venda.
- O vendedor pode cancelar uma venda.

### Gerente

- O gerente pode obter relatórios por data das vendas de um ou mais vendedores do setor.
- O gerente pode adicionar/cadastrar uma venda para um determinado vendedor.
- O gerente pode editar uma venda para um vendedor.
- O gerente pode cancelar uma venda para um vendedor.

### Administrador

- O administrador do sistema não pode manipular recursos de vendas.

### 03 - Gerenciamento do setor

### Gerentre

- Somente gerentes podem cadastrar vendedores no setor.
- Somente gerentes podem transferir vendedores de setor.
- Um vendedor não pode ser excluído de um setor.
- Um vendedor pode ser transferido de setor, mas as suas vendas ainda farão parte do setor em que foram cadastradas.

### Administrador

- Somente administradores poderão manipular os dados do setor.

### 04 - Catálogo de Produtos

##### Vendedor

- Um vendedor pode consultar produtos.
- Um vendedor pode adicionar produtos na sua venda.

#### Gerente

- Um administrador pode cadastrar produtos.
- Um administrador pode editar produtos.
- Um administrador pode desabilitar um produto.

### 05 - Controle de acesso

- Um usuário só poderá acessar a aplicação aw ele estiver devidamente cadastrado e autenticado.
- O sistema deve ter 03 níveis de acesso, sendo eles: Administrador, Gerente e Vendedor.
- Um usuário só poderá acessar recursos que o seu nível de acesso permita.
- Um usuário não poderá alterar seu e-mail.

### Ferramentas

- Esse projeto será criado utilizando [ASPNET 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
- ASP.NET 6 WEB API
- Fluent Validation
- Documentação com Swagger
- Autenticação
- Autorização
- JWT

As regras aqui descritas podem ser alteradas de acordo com o contexto em que essa aplicação vai ser utilizada.
