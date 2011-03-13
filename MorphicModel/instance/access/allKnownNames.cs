allKnownNames
	"Answer a list of all the names of all named objects borne in my instance variable values"

	^ super allKnownNames, (self instanceVariableValues select: [:e | (e ~~ nil) and: [e knownName ~~ nil]] thenCollect: [:e | e knownName])