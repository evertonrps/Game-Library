Funcionalidade: CreateDeveloper
	Um usuário acessa a tela de cadastro, 
	preenche os dados do cadastro e salva o registro	

@TesteAutomatizadoCadastroDeveloperSucesso
Cenário:Cadastro de Developer	
	Dado clica no link da area de developer
	E Acessa a tela de cadastro
	E Preenche os dados do formulario 
		| Campo     | Valor				  |
		| name      | Nintendo            |
		| founded   | 23/09/1889		  |
		| webSite   | http://nintendo.com |
	Quando Clica no botao Cadastrar
	Então Recebe uma mensagem de developer cadastrado  com sucesso
	E exclui o developer cadastrado	

@TesteAutomatizadoCadastroDeveloperFalha
Cenário:Cadastro de Developer sem nome	
	Dado clica no link da area de developer
	E Acessa a tela de cadastro
	E Preenche os dados do formulario 
		| Campo     | Valor				  |
		| name      |             |
		| founded   | 23/09/1889		  |
		| webSite   | http://nintendo.com |
	Então Recebe uma mensagem de nome obrigatorio
	E exclui o developer cadastrado	

@TesteAutomatizadoCadastroDeveloperFalha
Cenário:Cadastro de Developer com data futura	
	Dado clica no link da area de developer
	E Acessa a tela de cadastro
	E Preenche os dados do formulario 
		| Campo     | Valor				  |
		| name      | Nintendo            |
		| founded   | 23/09/2100		  |
		| webSite   | http://nintendo.com |
	Quando Clica no botao Cadastrar
	Então Recebe uma mensagem de data de fundacao invalida	