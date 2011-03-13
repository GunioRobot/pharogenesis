changeSetNamed: newName
	Smalltalk at: #ChangesOrganizer ifPresentAndInMemory: [ :cs | ^cs changeSetNamed: newName ].
	^ChangeSet allInstances detect: [ :cs | cs name = newName ] ifNone: [ nil ].