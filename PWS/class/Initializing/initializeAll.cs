initializeAll
	| anAuthorizer |
	anAuthorizer _ Authorizer new.
	anAuthorizer realm: 'AuthorizedSpace'.
	anAuthorizer mapName: 'owner' password: 'squeak' to: 'owner'.
	self link: 'authorized' to: (AuthorizedServerAction new authorizer: anAuthorizer).
	self link: 'chat' to: ChatPage new.
	self link: 'default' to: ServerAction new.
	self link: 'embedded' to: EmbeddedServerAction new.
	Comment setUpExample.
	self link: 'comment' to: (SinglePlugServerAction new 
			processBlock: [:request | Comment process: request]).
