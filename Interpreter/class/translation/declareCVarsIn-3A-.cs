declareCVarsIn: aCCodeGenerator

	aCCodeGenerator var: 'methodCache'
		declareC: 'int methodCache[', (MethodCacheSize + 1) printString, ']'.
	aCCodeGenerator var: 'localIP' declareC: 'char * localIP'.
	aCCodeGenerator var: 'localSP' declareC: 'char * localSP'.
	aCCodeGenerator var: 'semaphoresToSignal'
		declareC: 'int semaphoresToSignal[', (SemaphoresToSignalSize + 1) printString, ']'.
