dbStatusFor: rootFilename

	"See if the named databes exists. Since the database has several components, the answer is one of:
	#exists				all files exist, and were created in the right order
	#partialDatabase	only some of the files exist
	#doesNotExist		none of the files exist"

	| dir localName messageFileExists indexFileExists categoriesFileExists messageFileTime categoriesFileTime |

	dir _ FileDirectory forFileName: rootFilename.
	localName _ FileDirectory localNameFor: rootFilename.

	messageFileExists _ dir includesKey: localName, '.messages'.
	indexFileExists _ dir includesKey: localName, '.index'.
	categoriesFileExists _ dir includesKey: localName, '.categories'.

	"Check if no parts of the database exist"
	(messageFileExists | indexFileExists | categoriesFileExists) ifFalse: [^ #doesNotExist].

	"Check if the database was written in a normal sequence"
	(messageFileExists & indexFileExists & categoriesFileExists) ifTrue: [
		messageFileTime _ (dir entryAt: localName, '.messages') modificationTime.
		categoriesFileTime _ (dir entryAt: localName, '.categories') modificationTime.

		"Unfortunately the strongest thing we can say is that the message file should be the oldest file on disk, and the categories file the newest"
		(messageFileTime <= categoriesFileTime)
			ifTrue: [^ #exists].
		].

	^ #partialDatabase
