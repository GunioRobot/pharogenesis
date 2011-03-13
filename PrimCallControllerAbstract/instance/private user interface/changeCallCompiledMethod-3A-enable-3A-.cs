changeCallCompiledMethod: aCompiledMethod enable: enableFlag 
	"Enables disabled or disables enabled external prim call by recompiling 
	method with prim call taken from comment."
	|  methodRef |
	methodRef := aCompiledMethod methodReference.
	enableFlag
		ifTrue: [self enableCallIn: methodRef]
		ifFalse: [self disableCallIn: methodRef]