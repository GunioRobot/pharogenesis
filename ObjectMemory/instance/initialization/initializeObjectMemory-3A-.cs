initializeObjectMemory: bytesToShift
	"Initialize object memory variables at startup time. Assume endOfMemory is initially set (by the image-reading code) to the end of the last object in the image. Initialization redefines endOfMemory to be the end of the object allocation area based on the total available memory, but reserving some space for forwarding blocks."
	"Assume: image reader initializes the following variables:
		memory
		endOfMemory
		memoryLimit
		specialObjectsOop
		lastHash
	"
	"di 11/18/2000 fix slow full GC"
	self inline: false.

	"set the start of the young object space"
	youngStart _ endOfMemory.

	"image may be at a different address; adjust oops for new location"
	totalObjectCount _ self adjustAllOopsBy: bytesToShift.

	self initializeMemoryFirstFree: endOfMemory. "initializes endOfMemory, freeBlock"

	specialObjectsOop _ specialObjectsOop + bytesToShift.

	"heavily used special objects"
	nilObj	_ self splObj: NilObject.
	falseObj	_ self splObj: FalseObject.
	trueObj	_ self splObj: TrueObject.

	rootTableCount _ 0.
	freeContexts _ NilContext.
	freeLargeContexts _ NilContext.
	allocationCount _ 0.
	lowSpaceThreshold _ 0.
	signalLowSpace _ false.
	compStart _ 0.
	compEnd _ 0.
	fwdTableNext _ 0.
	fwdTableLast _ 0.
	remapBufferCount _ 0.
	allocationsBetweenGCs _ 4000.  "do incremental GC after this many allocations"
	tenuringThreshold _ 2000.  "tenure all suriving objects if count is over this threshold"
	growHeadroom _ 4*1024*1024. "four megabyte of headroom when growing"
	shrinkThreshold _ 8*1024*1024. "eight megabyte of free space before shrinking"

	"garbage collection statistics"
	statFullGCs _ 0.
	statFullGCMSecs _ 0.
	statIncrGCs _ 0.
	statIncrGCMSecs _ 0.
	statTenures _ 0.
	statRootTableOverflows _ 0.
