externalPrimitives
	"InterpreterSupportCode externalPrimitives"

	| unexported |
	Interpreter initialize.
	unexported _ self unexportedPrimitives.
	^(Interpreter primitiveTable asSet reject: [:sel | Interpreter includesSelector: sel])
		asSortedCollection
		reject: [:prim | unexported includes: prim]