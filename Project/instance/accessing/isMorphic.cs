isMorphic
	"Complexity is because #isMVC is lazily installed"
	^ world isInMemory 
		ifTrue: [world isMorph]
		ifFalse: [(self projectParameters at: #isMVC ifAbsent: [false]) not]