readImageFromFile: f HeapSize: desiredHeapSize StartingAt: imageOffset
	"Read an image from the given file stream, allocating the given amount of memory to its object heap. Fail if the image has an unknown format or requires more than the given amount of memory."
	"Details: This method detects when the image was stored on a machine with the opposite byte ordering from this machine and swaps the bytes automatically. Furthermore, it allows the header information to start 512 bytes into the file, since some file transfer programs for the Macintosh apparently prepend a Mac-specific header of this size. Note that this same 512 bytes of prefix area could also be used to store an exec command on Unix systems, allowing one to launch Smalltalk by invoking the image name as a command."
	"This code is based on C code by Ian Piumarta and Smalltalk code by Tim Rowledge. Many thanks to both of you!!"

	| swapBytes headerStart headerSize dataSize oldBaseAddr minimumMemory memStart bytesRead bytesToShift heapSize |
	self var: #f declareC: 'sqImageFile f'.

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
		GenerateBrowserPlugin
			ifTrue: [
				self plugInNotifyUser: 'The amount of memory specified by the ''memory'' EMBED tag is not enough for the installed Squeak image file.'.
				^ nil]
			ifFalse: [self error: 'Insufficient memory for this image']].

	"allocate a contiguous block of memory for the Squeak heap"
	memory _ self cCode: '(unsigned char *) sqAllocateMemory(minimumMemory, heapSize)'.
	memory = nil ifTrue: [
		GenerateBrowserPlugin
			ifTrue: [
				self plugInNotifyUser: 'There is not enough memory to give Squeak the amount specified by the ''memory'' EMBED tag.'.
				^ nil]
			ifFalse: [self error: 'Failed to allocate memory for the heap']].

	memStart _ self startOfMemory.
	memoryLimit _ (memStart + heapSize) - 24.  "decrease memoryLimit a tad for safety"
	endOfMemory _ memStart + dataSize.

	"position file after the header"
	self sqImageFile: f Seek: headerStart + headerSize.

	"read in the image in bulk, then swap the bytes if necessary"
	bytesRead _ self cCode: 'sqImageFileRead(memory, sizeof(unsigned char), dataSize, f)'.
	bytesRead ~= dataSize ifTrue: [
		GenerateBrowserPlugin
			ifTrue: [
				self plugInNotifyUser: 'Squeak had problems reading its image file.'.
				self plugInShutdown.
				^ nil]
			ifFalse: [self error: 'Read failed or premature end of image file']].
	swapBytes ifTrue: [self reverseBytesInImage].

	"compute difference between old and new memory base addresses"
	bytesToShift _ memStart - oldBaseAddr.
	self initializeInterpreter: bytesToShift.  "adjusts all oops to new location"
	^ dataSize
