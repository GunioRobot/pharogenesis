snapshot: embedded 
	"update state of active context"
	| activeProc dataSize rcvr setMacType |
	compilerInitialized
		ifTrue: [self compilerPreSnapshot]
		ifFalse: [self storeContextRegisters: activeContext].

	"update state of active process"
	activeProc _ self fetchPointer: ActiveProcessIndex ofObject: self schedulerPointer.
	self
		storePointer: SuspendedContextIndex
		ofObject: activeProc
		withValue: activeContext.

	"compact memory and compute the size of the memory actually in use"
	self incrementalGC.

	"maximimize space for forwarding table"
	self fullGC.
	self snapshotCleanUp.

	dataSize _ freeBlock - self startOfMemory. "Assume all objects are below the start of the free block"
	successFlag
		ifTrue: [rcvr _ self popStack.
			"pop rcvr"
			self push: trueObj.
			self writeImageFile: dataSize.
			embedded
				ifFalse: ["set Mac file type and creator; this is a noop on other platforms"
					setMacType _ self ioLoadFunction: 'setMacFileTypeAndCreator' From: 'FilePlugin'.
					setMacType = 0
						ifFalse: [self cCode: '((int (*) (char*, char*, char*)) setMacType) (getImageName(), "STim", "FAST")']].
			self pop: 1].

	"activeContext was unmarked in #snapshotCleanUp, mark it old "
	self beRootIfOld: activeContext.
	successFlag
		ifTrue: [self push: falseObj]
		ifFalse: [self push: rcvr].
	compilerInitialized
		ifTrue: [self compilerPostSnapshot]