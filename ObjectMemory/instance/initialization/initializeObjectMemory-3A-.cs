initializeObjectMemory: bytesToShift
	"Initialize object memory variables at startup time. Assume endOfMemory is initially set (by the image-reading code) to the end of the last object in the image. Initialization redefines endOfMemory to be the end of the object allocation area based on the total available memory, but reserving some space for forwarding blocks."
	"Assume: image reader initializes the following variables:
		memory
		endOfMemory
		memoryLimit
		specialObjectsOop
		lastHash
	"

	self inline: false.
	checkAssertions _ false.  "set this early to allow assertions in initialization code to use it"

	"set the start of the young object space"
	youngStart _ endOfMemory.
	self initializeMemoryFirstFree: endOfMemory.
		"initializes endOfMemory, freeBlock"

	"image may be at a different address; adjust oops for new location"
	self adjustAllOopsBy: bytesToShift.
	specialObjectsOop _ specialObjectsOop + bytesToShift.

	"heavily used special objects"
	nilObj	_ self splObj: NilObject.
	falseObj	_ self splObj: FalseObject.
	trueObj	_ self splObj: TrueObject.

	rootTableCount _ 0.
	child _ 0.
	field _ 0.
	parentField _ 0.
	freeLargeContexts _ NilContext.
	freeSmallContexts _ NilContext.
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

	"garbage collection statistics"
	statFullGCs _ 0.
	statFullGCMSecs _ 0.
	statIncrGCs _ 0.
	statIncrGCMSecs _ 0.
	statTenures _ 0.
	statRootTableOverflows _ 0.

	displayBits _ 0.  "support for the Acorn VM; ignored if zero"
