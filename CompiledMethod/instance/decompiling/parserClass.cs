parserClass
	^ self isClosureCompiled 
			ifTrue: [self compilerClass closureParserClass] 
			ifFalse: [self compilerClass parserClass]