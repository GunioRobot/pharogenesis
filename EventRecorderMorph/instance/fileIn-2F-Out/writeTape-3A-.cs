writeTape: fileName 
	| b name |
	name _ self writeFileNamed: fileName.
	(b _ self button: 'writeTape') ifNotNil: [b arguments: (Array with: name)].
