openOn: rootNameString
	"Open a mail database with the given root file name."

	| status |
	rootFilename _ rootNameString.
	status _ self dbStatus.
	messageFile _ indexFile _ categoriesFile _ spamFilterFile _ nil.
	(status = #exists) ifTrue: [^self openDB].
	(status = #partialDatabase) ifTrue: [^self recoverDB].
	(status = #doesNotExist) ifTrue: [^self createDB].