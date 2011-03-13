storeCurrentServersIn: aDirectory

	| file |
	self servers do: [:each |
		file := aDirectory fileNamed: (ServerDirectory nameForServer: each).
		each storeServerEntryOn: file.
		file close].
	