gcReachableFrom: selector
	"Answer whether the given selector can trigger a garbage collection."
	"InterpreterSupportCode gcReachableFrom: #primitiveClass"
	"InterpreterSupportCode gcReachableFrom: #primitiveFullGC"
	"InterpreterSupportCode gcReachableFrom: #primitiveAt"
	"InterpreterSupportCode gcReachableFrom: #primitiveArrayBecome"
	"InterpreterSupportCode gcReachableFrom: #primitiveStoreImageSegment"

	| method messages prevSize |
	method _ Interpreter compiledMethodAt: selector ifAbsent: [^false].
	messages _ (method literals select: [:sel |
					(Interpreter includesSelector: sel) or: [ObjectMemory includesSelector: sel]]) asSet.
	prevSize _ 0.
	[messages size > prevSize] whileTrue:
		[prevSize _ messages size.
		 messages copy do: [:sel |
			method _ Interpreter compiledMethodAt: sel ifAbsent: [ObjectMemory compiledMethodAt: sel].
			messages addAll: (method literals select: [:sel2 |
					(Interpreter includesSelector: sel2) or: [ObjectMemory includesSelector: sel2]])].
		 ((messages includes: #mapPointersInObjectsFrom:to:)
			or: [messages includes: #markAndTraceInterpreterOops]) ifTrue: [^true]].
	^false