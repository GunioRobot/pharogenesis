allocateOrRecycleContext: smallContextWanted
	"Return a recycled context or a newly allocated one if none is available for recycling. The argument indicates that a small context is wanted."

	| cntxt |
	self inline: true.
	smallContextWanted ifTrue: [
		freeSmallContexts ~= NilContext ifTrue: [
			cntxt _ freeSmallContexts.
			freeSmallContexts _ self fetchPointer: 0 ofObject: cntxt.
		] ifFalse: [
			cntxt _ self instantiateSmallClass: (self splObj: ClassMethodContext)
								 sizeInBytes: SmallContextSize
										 fill: nilObj.
		].
	] ifFalse: [
		freeLargeContexts ~= NilContext ifTrue: [
			cntxt _ freeLargeContexts.
			freeLargeContexts _ self fetchPointer: 0 ofObject: cntxt.
		] ifFalse: [
			cntxt _ self instantiateSmallClass: (self splObj: ClassMethodContext)
								sizeInBytes: LargeContextSize
										fill: nilObj.
		].
	].
	^ cntxt
