declareCVarsIn: aCCodeGenerator
	aCCodeGenerator 
		var: #interpreterProxy 
		type: #'struct VirtualMachine*'.
	aCCodeGenerator
		var: #methodCache
		declareC: 'int methodCache[', (MethodCacheSize + 1) printString, ']'.
	aCCodeGenerator
		var: #atCache
		declareC: 'int atCache[', (AtCacheTotalSize + 1) printString, ']'.
	aCCodeGenerator var: #localIP type: #'char*'.
	aCCodeGenerator var: #localSP type: #'char*'.
	aCCodeGenerator var: 'semaphoresToSignalA'
		declareC: 'int semaphoresToSignalA[', (SemaphoresToSignalSize + 1) printString, ']'.
	aCCodeGenerator var: 'semaphoresToSignalB'
		declareC: 'int semaphoresToSignalB[', (SemaphoresToSignalSize + 1) printString, ']'.
	aCCodeGenerator
		var: #compilerHooks
		declareC: 'int (*compilerHooks[', (CompilerHooksSize + 1) printString, '])()'.
	aCCodeGenerator
		var: #interpreterVersion
		declareC: 'const char *interpreterVersion = "', Smalltalk version, ' [', Smalltalk lastUpdateString,']"'.
	aCCodeGenerator
		var: #obsoleteIndexedPrimitiveTable
		declareC: 'char* obsoleteIndexedPrimitiveTable[][3] = ', self obsoleteIndexedPrimitiveTableString.
	aCCodeGenerator
		var: #obsoleteNamedPrimitiveTable
		declareC: 'const char* obsoleteNamedPrimitiveTable[][3] = ', self obsoleteNamedPrimitiveTableString.
	aCCodeGenerator
		var: #externalPrimitiveTable
		declareC: 'int externalPrimitiveTable[', (MaxExternalPrimitiveTableSize + 1) printString, ']'.
