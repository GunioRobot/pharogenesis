declareCVarsIn: aCCodeGenerator
	aCCodeGenerator var: #memory type: #'unsigned char*'.
	aCCodeGenerator
		var: #remapBuffer
		declareC: 'int remapBuffer[', (RemapBufferSize + 1) printString, ']'.
	aCCodeGenerator
		var: #rootTable
		declareC: 'int rootTable[', (RootTableSize + 1) printString, ']'.
	aCCodeGenerator
		var: #headerTypeBytes
		declareC: 'int headerTypeBytes[4]'.
	
	aCCodeGenerator var: #youngStart type: 'unsigned'.
	aCCodeGenerator var: #endOfMemory type: 'unsigned'.
	aCCodeGenerator var: #memoryLimit type: 'unsigned'.
	aCCodeGenerator var: #youngStartLocal type: 'unsigned'.
