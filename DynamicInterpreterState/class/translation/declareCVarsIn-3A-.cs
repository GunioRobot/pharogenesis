declareCVarsIn: aCCodeGenerator

	"aCCodeGenerator var: 'localTP' declareC: 'char * localTP'."
	aCCodeGenerator var: 'localCP' declareC: 'int localCP'.

	aCCodeGenerator var: 'methodCache'
		declareC: 'int methodCache[', (MethodCacheSize + 1) printString, ']'.
	aCCodeGenerator var: 'localIP' declareC: 'char * localIP'.
	aCCodeGenerator var: 'localSP' declareC: 'char * localSP'.
	aCCodeGenerator var: 'semaphoresToSignal'
		declareC: 'int semaphoresToSignal[', (SemaphoresToSignalSize + 1) printString, ']'.
