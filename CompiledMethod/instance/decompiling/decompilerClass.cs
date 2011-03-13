decompilerClass
	^ self isClosureCompiled
			ifTrue: [self compilerClass closureDecompilerClass] 
			ifFalse: [self compilerClass decompilerClass]