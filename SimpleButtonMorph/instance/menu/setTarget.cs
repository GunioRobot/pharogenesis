setTarget
	
	| newLabel |
	newLabel := FillInTheBlank request: 'Enter an expression that create the target' translated initialAnswer: 'World'.
	newLabel isEmpty
		ifFalse: [self target: (Compiler evaluate: newLabel)]