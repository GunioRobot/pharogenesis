storeCurrentServersIn: aDirectory

	| file |
	self servers do: [:each |
		file _ aDirectory fileNamed: (ServerDirectory nameForServer: each).
		each storeServerEntryOn: file.
		file close].
	self localProjectDirectories do: [:each |
		file _ aDirectory fileNamed: each localName.
		each storeServerEntryOn: file.
		file close].
