readImageFromFile: f HeapSize: desiredHeapSize StartingAt: imageOffset
	"Read an image from the given file stream, allocating the given amount of memory to its object heap. Fail if the image has an unknown format or requires more than the given amount of memory."
	"Details: This method detects when the image was stored on a machine with the opposite byte ordering from this machine and swaps the bytes automatically. Furthermore, it allows the header information to start 512 bytes into the file, since some file transfer programs for the Macintosh apparently prepend a Mac-specific header of this size. Note that this same 512 bytes of prefix area could also be used to store an exec command on Unix systems, allowing one to launch Smalltalk by invoking the image name as a command."
	"This code is based on C code by Ian Piumarta and Smalltalk code by Tim Rowledge. Many thanks to both of you!!"

	| swapBytes headerStart headerSize dataSize oldBaseAddr minimumMemory memStart bytesRead bytesToShift heapSize |
	self var: #f declareC: 'sqImageFile f'.
	self var: #headerStart declareC: 'squeakFileOffsetType headerStart'.
	self var: #dataSize declareC: 'size_t dataSize'.
	self var: #imageOffset declareC: 'squeakFileOffsetType imageOffset'.
	self var: #memStart type: 'unsigned'.

	swapBytes _ self checkImageVersionFrom: f startingAt: imageOffset.
	headerStart _ (self sqImageFilePosition: f) - 4.  "record header start position"

	headerSize			_ self getLongFromFile: f swap: swapBytes.
	dataSize				_ self getLongFromFile: f swap: swapBytes.
	oldBaseAddr			_ self getLongFromFile: f swap: swapBytes.
	specialObjectsOop	_ self getLongFromFile: f swap: swapBytes.
	lastHash			_ self getLongFromFile: f swap: swapBytes.
	savedWindowSize	_ self getLongFromFile: f swap: swapBytes.
	fullScreenFlag		_ self getLongFromFile: f swap: swapBytes.
	extraVMMemory		_ self getLongFromFile: f swap: swapBytes.

	lastHash = 0 ifTrue: [
		"lastHash wasn't stored (e.g. by the cloner); use 999 as the seed"
		lastHash _ 999].

	"decrease Squeak object heap to leave extra memory for the VM"
	heapSize _ self cCode: 'reserveExtraCHeapBytes(desiredHeapSize, extraVMMemory)'.

	"compare memory requirements with availability".
	minimumMemory _ dataSize + 100000.  "need at least 100K of breathing room"
	heapSize < minimumMemory ifTrue: [
		self insufficientMemorySpecifiedError].

	"allocate a contiguous block of memory for the Squeak heap"
	memory _ self cCode: '(unsigned char *) sqAllocateMemory(minimumMemory, heapSize)'.
	memory = nil ifTrue: [self insufficientMemoryAvailableError].

	memStart _ self startOfMemory.
	memoryLimit _ (memStart + heapSize) - 24.  "decrease memoryLimit a tad for safety"
	endOfMemory _ memStart + dataSize.

	"position file after the header"
	self sqImageFile: f Seek: headerStart + headerSize.

	"read in the image in bulk, then swap the bytes if necessary"
	bytesRead _ self cCode: 'sqImageFileRead(memory, sizeof(unsigned char), dataSize, f)'.
	bytesRead ~= dataSize ifTrue: [self unableToReadImageError].

	headerTypeBytes at: 0 put: 8. "3-word header (type 0)"	
	headerTypeBytes at: 1 put: 4. "2-word header (type 1)"
	headerTypeBytes at: 2 put: 0. "free chunk (type 2)"	
	headerTypeBytes at: 3 put: 0. "1-word header (type 3)"

	swapBytes ifTrue: [self reverseBytesInImage].

	"compute difference between old and new memory base addresses"
	bytesToShift _ memStart - oldBaseAddr.
	self initializeInterpreter: bytesToShift.  "adjusts all oops to new location"
	^ dataSize
