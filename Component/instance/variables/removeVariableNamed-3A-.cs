removeVariableNamed: varName 
	self class removeSelector: varName.
	self class removeSelector: (varName , 'Set:') asSymbol.
	self class removeInstVarName: varName asString