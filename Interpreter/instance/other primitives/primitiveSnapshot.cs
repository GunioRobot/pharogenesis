primitiveSnapshot

	| activeProc dataSize rcvr |

	"update state of active context"
	compilerInitialized
		ifTrue: [self compilerPreSnapshot]
		ifFalse: [self storeContextRegisters: activeContext].

	"update state of active process"
	activeProc _ self
		fetchPointer: ActiveProcessIndex
		ofObject: self schedulerPointer.
	self	storePointer: SuspendedContextIndex
		ofObject: activeProc
		withValue: activeContext.

	"compact memory and compute the size of the memory actually in use"
	self cleanUpContexts.
	self incrementalGC.  "maximimize space for forwarding table"
	self fullGC.

	dataSize _ freeBlock - (self startOfMemory).
	"Assume: all objects are below the start of the free block"

	successFlag ifTrue: [
		rcvr _ self popStack.  "pop rcvr"
		self push: trueObj.
		self writeImageFile: dataSize.
		self pop: 1.  "pop true"
	].
	successFlag
		ifTrue: [ self push: falseObj ]
		ifFalse: [ self push: rcvr ].

	compilerInitialized
		ifTrue: [self compilerPostSnapshot].