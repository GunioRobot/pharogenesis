extractCallModuleNamesFromLiterals: aMethodRef 
	| firstLiteral |
	firstLiteral := aMethodRef compiledMethod literals first.
	^ (firstLiteral at: 2)
		-> (firstLiteral at: 1)