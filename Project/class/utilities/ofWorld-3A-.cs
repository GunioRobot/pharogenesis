ofWorld: aPasteUpMorph
	"Find the project of a world."

	"Usually it is the current project"
	self current world == aPasteUpMorph ifTrue: [^ self current].

	"Inefficient enumeration if it is not..."
	^ self allSubInstances
		detect:
		[:pr | pr world isInMemory 
			ifTrue: [pr world == aPasteUpMorph]
			ifFalse: [false]]
		ifNone: [nil]