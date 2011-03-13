unexportedPrimitives
	"Answer an Array containing the names of the primitives that are not exported to j3."
	"InterpreterSupportCode unexportedPrimitives"

	| prims missing |
	prims _ #(primitiveAt primitiveAtPut primitiveBlockCopy primitiveClone
		primitiveDoPrimitiveWithArgs primitiveExternalCall primitiveInstVarAt
		primitiveInstVarAtPut primitiveInstVarsPutFromStack primitiveLoadInstVar
		primitivePerform primitivePerformInSuperclass primitivePerformWithArgs
		primitiveResume primitiveSignal primitiveSize primitiveSnapshot
		primitiveStoreStackp primitiveStringAt primitiveStringAtPut primitiveSuspend
		primitiveValue primitiveValueWithArgs primitiveWait
		primitiveObsoleteIndexedPrimitive).
	missing _ prims reject: [:prim | Interpreter primitiveTable includes: prim].
	missing isEmpty ifFalse: [self error: 'missing primitives: ' , missing printString].
	^prims