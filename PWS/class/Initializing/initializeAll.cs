initializeAll
	| anAuthorizer |
	anAuthorizer _ Authorizer new.
	anAuthorizer realm: 'AuthorizedSpace'.
"	anAuthorizer mapName: 'JSmith' password: 'hard2guess' to: 'JSmith'.  "
		"No default account!  See howToStart to enable remote code execution."
	self link: 'authorized' to: (AuthorizedServerAction new authorizer: anAuthorizer).
	self link: 'chat' to: ChatPage new.
	self link: 'default' to: ServerAction new.
	self link: 'embedded' to: EmbeddedServerAction new.
	self link: 'smtlk' to: CodeServer new.
	self link: 'chunk' to: CodeServer new.
	Comment setUpExample.
	self link: 'comment' to: (SinglePlugServerAction new 
			processBlock: [:request | Comment process: request]).
