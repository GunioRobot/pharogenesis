basicNewChangeSet: newName 
	"This method copied here to ensure SqueakMap is independent of 
	ChangeSorter. "
	Smalltalk
		at: #ChangeSorter
		ifPresentAndInMemory: [:cs | ^ cs basicNewChangeSet: newName].
	(self changeSetNamed: newName)
		ifNotNil: [self error: 'The name ' , newName , ' is already used'].
	^ ChangeSet basicNewNamed: newName