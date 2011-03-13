setTarget
	
	| newLabel |
	newLabel := UIManager default request: 'Enter an expression that create the target' translated initialAnswer: 'World'.
	newLabel isEmptyOrNil
		ifFalse: [self target: (Compiler evaluate: newLabel)]