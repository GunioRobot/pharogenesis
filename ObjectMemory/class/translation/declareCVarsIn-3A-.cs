declareCVarsIn: aCCodeGenerator

	aCCodeGenerator var: 'memory'
		declareC: 'unsigned char *memory'.
	aCCodeGenerator var: 'remapBuffer'
		declareC: 'int remapBuffer[', (RemapBufferSize + 1) printString, ']'.
	aCCodeGenerator var: 'rootTable'
		declareC: 'int rootTable[', (RootTableSize + 1) printString, ']'.