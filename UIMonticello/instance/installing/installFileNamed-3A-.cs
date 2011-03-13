installFileNamed: filename 
	(filename asLowercase endsWith: '.mcm') 
		ifTrue: [^ self mcmReader loadVersionFile: filename].
	Smalltalk at: #MCMczReader
		ifPresent: [:reader | ^ reader loadVersionFile: filename].
	MczInstaller installFileNamed: filename