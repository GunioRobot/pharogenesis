isKnownVarName: newVarName
	"Return true if this variable is already known, as an argument, temp var, block temp, or instance variable."

	| syntLevel |
	(self parsedInClass allInstVarNames includes: newVarName) ifTrue: [^ true].
	syntLevel _ self.
	[syntLevel tempVarNodesDo: [:node | 
		node decompile string = newVarName ifTrue: [^ true]].
	 (syntLevel _ syntLevel owner) isSyntaxMorph] whileTrue.
	^ false