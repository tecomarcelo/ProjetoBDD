#language: pt

Funcionalidade: Criar conta de usuário
	Como um usuário do sistema
	Eu quero criar uma conta
	Para que eu possa acessar a aplicação

Contexto: 
	Dado eu acesso a página de criação de conta de usuário

Cenário: Criação conta de usuário com sucesso
	E eu informo nome, email e senha válidos
	Quando eu solicito a realização do cadastro
	Então o sistema informa que o usuário foi cadastrado com sucesso

Cenário: Não permitir o cadastro de usuários com email já existente
	E eu informo nome, senha e um email já cadastrado
	Quando eu solicito a realização do cadastro
	Então o sistema informa que o email já foi cadastrado para outro usuário

Cenário: Validar todos os campos como obrigatórios
	E eu não preencho nome, email e senha
	Quando eu solicito a realização do cadastro
	Então o sistema informa que todos os campos são de preenchimento obrigatório
