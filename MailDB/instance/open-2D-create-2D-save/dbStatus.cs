dbStatus
	"See if my database exists. Since the database has several components, the answer is one of:
	#exists				all files exist
	#partialDatabase	only some of the files exist
	#doesNotExist		none of the files exist"

	| dir localName |
	dir _ FileDirectory forFileName: rootFilename.
	localName _ FileDirectory localNameFor: rootFilename.
	messageFile _ dir includesKey: localName, '.messages'.
	indexFile _ dir includesKey: localName, '.index'.
	categoriesFile _ dir includesKey: localName, '.categories'.
	(messageFile & indexFile & categoriesFile) ifTrue: [^ #exists].
	(messageFile | indexFile | categoriesFile) ifFalse: [^ #doesNotExist].
	^ #partialDatabase
