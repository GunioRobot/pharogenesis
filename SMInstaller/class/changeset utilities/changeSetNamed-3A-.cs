changeSetNamed: newName
	"This method copied here to ensure SqueakMap is independent of ChangeSorter."

	Smalltalk at: #ChangeSorter ifPresentAndInMemory: [ :cs | ^cs changeSetNamed: newName ].
	^ChangeSet allInstances detect: [ :cs | cs name = newName ] ifNone: [ nil ].