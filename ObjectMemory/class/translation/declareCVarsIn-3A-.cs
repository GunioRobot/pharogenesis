declareCVarsIn: aCCodeGenerator
	aCCodeGenerator var: #memory type: #'unsigned char*'.
	aCCodeGenerator
		var: #remapBuffer
		declareC: 'int remapBuffer[', (RemapBufferSize + 1) printString, ']'.
	aCCodeGenerator
		var: #rootTable
		declareC: 'int rootTable[', (RootTableSize + 1) printString, ']'