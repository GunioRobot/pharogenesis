allocateOrRecycleContext: needsLarge
	"Return a recycled context or a newly allocated one if none is available for recycling."
	| cntxt |
	needsLarge = 0
	ifTrue: [freeContexts ~= NilContext ifTrue:
				[cntxt _ freeContexts.
				freeContexts _ self fetchPointer: 0 ofObject: cntxt.
				^ cntxt]]
	ifFalse: [freeLargeContexts ~= NilContext ifTrue:
				[cntxt _ freeLargeContexts.
				freeLargeContexts _ self fetchPointer: 0 ofObject: cntxt.
				^ cntxt]].
	
	needsLarge = 0
		ifTrue: [cntxt _ self instantiateContext: (self splObj: ClassMethodContext)
				sizeInBytes: SmallContextSize]
		ifFalse: [cntxt _ self instantiateContext: (self splObj: ClassMethodContext)
				sizeInBytes: LargeContextSize].
	"Required init -- above does not fill w/nil.  All others get written."
	self storePointerUnchecked: 4 "InitialIPIndex" ofObject: cntxt
					withValue: nilObj.
	^ cntxt
