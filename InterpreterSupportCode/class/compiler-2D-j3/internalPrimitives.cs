internalPrimitives
	"InterpreterSupportCode internalPrimitives"

	| unexported |
	Interpreter initialize.
	unexported _ self unexportedPrimitives.
	^(Interpreter primitiveTable asSet select: [:sel | Interpreter includesSelector: sel])
		asSortedCollection reject: [:prim | unexported includes: prim].