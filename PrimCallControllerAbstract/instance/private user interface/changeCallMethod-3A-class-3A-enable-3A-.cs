changeCallMethod: selector class: classOrSymbol enable: enableFlag 
	"Enables disabled or disables enabled external prim call by recompiling  
	method with prim call taken from comment."
	| methodRef |
	methodRef := MethodReference new
				setStandardClass: (classOrSymbol isSymbol
						ifTrue: [Smalltalk at: classOrSymbol]
						ifFalse: [classOrSymbol])
				methodSymbol: selector.
	enableFlag
		ifTrue: [self enableCallIn: methodRef]
		ifFalse: [self disableCallIn: methodRef]