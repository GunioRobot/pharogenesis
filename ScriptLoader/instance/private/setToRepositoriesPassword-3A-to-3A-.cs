setToRepositoriesPassword: aPassword to: aUser
	"self new setToRepositoriesPassword: '' to: ''"
	
	MCRepositoryGroup instVarNamed: 'default' put: nil. 
	self removeAllRepositories: {self repository locationWithTrailingSlash . self inboxRepository locationWithTrailingSlash}. 
	self repository password: aPassword.
	self repository user: aUser.
	self inboxRepository password: aPassword.
	self inboxRepository user: aUser.
	self addHomeRepositoryToAllPackages