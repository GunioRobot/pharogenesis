changeSetNamed: newName
	Smalltalk at: #ChangeSorter ifPresentAndInMemory: [ :cs | ^cs changeSetNamed: newName ].
	^ChangeSet allInstances detect: [ :cs | cs name = newName ] ifNone: [ nil ].