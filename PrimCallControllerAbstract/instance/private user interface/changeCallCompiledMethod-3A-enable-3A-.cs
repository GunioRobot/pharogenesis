changeCallCompiledMethod: aCompiledMethod enable: enableFlag 
	"Enables disabled or disables enabled external prim call by recompiling 
	method with prim call taken from comment."
	| who methodRef |
	who := aCompiledMethod who.
	methodRef := MethodReference new
				setStandardClass: (who at: 1)
				methodSymbol: (who at: 2).
	enableFlag
		ifTrue: [self enableCallIn: methodRef]
		ifFalse: [self disableCallIn: methodRef]