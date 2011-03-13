isMorphic
	"Complexity is because #isMVC is lazily installed"
	self deprecated: 'MVC has been removed.'.
	^ world isInMemory 
		ifTrue: [world isMorph]
		ifFalse: [(self projectParameters at: #isMVC ifAbsent: [false]) not]