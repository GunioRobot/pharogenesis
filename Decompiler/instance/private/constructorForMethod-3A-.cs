constructorForMethod: aMethod
	^(aMethod isBlueBookCompiled
		ifTrue: [DecompilerConstructor]
		ifFalse: [DecompilerConstructorForClosures]) new