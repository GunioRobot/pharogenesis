fileIn
	"Installing in the standard installer is simply filing in.
	Both .st and .cs files will file into a ChangeSet of their own.
	We let the user confirm filing into an existing ChangeSet
	or specify another ChangeSet name if
	the name derived from the filename already exists."
	
	| fileStream |
	((unpackedFileName endsWith: (FileDirectory dot, FileStream st))
		or: [unpackedFileName endsWith: (FileDirectory dot, FileStream cs)])
		ifTrue:[
			fileStream _ dir readOnlyFileNamed: unpackedFileName.
			fileStream setConverterForCode.
			self fileIntoChangeSetNamed: (fileStream localName sansPeriodSuffix)
				fromStream: fileStream.
			^ self].
"	((unpackedFileName endsWith: (FileDirectory dot, FileStream multiSt))
		or: [unpackedFileName endsWith: (FileDirectory dot, FileStream multiCs)])
		ifTrue:[
			fileStream _ dir readOnlyFileNamed: unpackedFileName.
			fileStream converter: UTF8TextConverter new.
			self fileIntoChangeSetNamed: (fileStream localName sansPeriodSuffix)
				fromStream: fileStream.
			^ self].
"
	self error: 'Filename should end with a proper extension'.
