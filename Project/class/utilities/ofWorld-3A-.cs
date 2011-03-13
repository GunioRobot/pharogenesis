ofWorld: aPasteUpMorph
	"Find the project of a world."

	"Usually it is the current project"
	CurrentProject world == aPasteUpMorph ifTrue: [^ CurrentProject].

	"Inefficient enumeration if it is not..."
	^ self allProjects detect: [:pr |
		pr world isInMemory 
			ifTrue: [pr world == aPasteUpMorph]
			ifFalse: [false]]
		ifNone: [nil]