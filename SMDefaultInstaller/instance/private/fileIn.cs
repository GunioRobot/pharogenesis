fileIn
	"Installing in the standard installer is simply filing in.
	Both .st and .cs files will file into a ChangeSet of their own.
	We let the user confirm filing into an existing ChangeSet
	or specify another ChangeSet name if
	the name derived from the filename already exists."
	
	| fileStream |
	(self class nonMultiSuffixes anySatisfy: [:each | unpackedFileName endsWith: (FileDirectory dot, each)])
		ifTrue:[
			fileStream := dir readOnlyFileNamed: unpackedFileName.
			(fileStream respondsTo: #setConverterCode) ifTrue: [fileStream setConverterForCode].
			self fileIntoChangeSetNamed: (fileStream localName sansPeriodSuffix) fromStream: fileStream.
			^self].
	(self class multiSuffixes anySatisfy: [:each | unpackedFileName endsWith: (FileDirectory dot, each)])
		ifTrue:[
			fileStream := dir readOnlyFileNamed: unpackedFileName.
			"Only images with converters should have multi suffixes"
			fileStream converter: (Smalltalk at: #UTF8TextConverter) new.
			self fileIntoChangeSetNamed: (fileStream localName sansPeriodSuffix) fromStream: fileStream.
			^self].
	self error: 'Filename should end with a proper extension'.
