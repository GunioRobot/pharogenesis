declareCVarsIn: aCCodeGenerator
	aCCodeGenerator var: 'opTable'
		declareC: 'int opTable[' , OpTableSize printString , ']'