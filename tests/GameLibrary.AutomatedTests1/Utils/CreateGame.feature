Funcionalidade: Cadastro Game
	Um usuario registrado com permissao de administrador ARTESP
	efetua o cadastro de uma game	

@TesteAutomatizadoCadastroGameSucesso

Cenário: Usuario cadastra game
	Dado que o usuário acessa a tela de cadastro de games
	E Clica no link do sistema Sisf TC
	E Clica no link de game
	E Seleciona um Fiscal	
			| Campo   | Valor|
			| Usuario | 3    |
	E Clica no botao de Adicionar	
	E Preenche os dados da game
			| Campo     | Valor      |
			| Terminal  | 20         |
			| Prazo     | 3          |
			| Empresa   | 4049       |
			| Data      | 19/10/2100 |
			| HoraInicio| 10:00      |
			| HoraFim   | 16:32      |
	Quando Clica no botao salvar
	Então Recebe uma mensagem de game Cadastrada com sucesso
	E exclui a programação cadastrada
	E Efetua Saida do Sistema
