openOn: fileName extraMemory: extraBytes
	"InterpreterSimulator new openOn: 'clone.im' extraMemory: 100000"

	| f version headerSize count oldBaseAddr bytesToShift swapBytes totalMemory |
	"open image file and read the header"
	checkAssertions _ false.
	f _ FileStream oldFileNamed: fileName.
	imageName _ f fullName.
	f binary; readOnly.
	version _ self nextLongFrom: f.  "current version: 16r1966 (=6502)"
	version = self imageFormatVersion
		ifTrue: [swapBytes _ false]
		ifFalse: [(version _ self byteSwapped: version) = self imageFormatVersion
					ifTrue: [swapBytes _ true]
					ifFalse: [self error: 'incomaptible image format']].
	headerSize _ self nextLongFrom: f swap: swapBytes.
	endOfMemory _ self nextLongFrom: f swap: swapBytes.  "first unused location in heap"
	oldBaseAddr _ self nextLongFrom: f swap: swapBytes.  "object memory base address of image"
	specialObjectsOop _ self nextLongFrom: f swap: swapBytes.
	lastHash _ self nextLongFrom: f swap: swapBytes.  "Should be loaded from, and saved to the image header"
	savedWindowSize _ self nextLongFrom: f swap: swapBytes.
	lastHash = 0 ifTrue: [lastHash _ 999].

	"allocate interpreter memory"
	contextCacheEntries = nil ifTrue: [contextCacheEntries _ ContextCacheEntries].
	stackCacheEntries = nil ifTrue: [stackCacheEntries _ StackCacheEntries].
	memoryLimit _ endOfMemory + extraBytes.
	totalMemory _ memoryLimit + self cacheSize.

	"read in the image in bulk, then swap the bytes if necessary"
	f position: headerSize.
	memory _ Bitmap new: totalMemory // 4.
	count _ f readInto: memory startingAt: 1 count: endOfMemory // 4.
	count ~= (endOfMemory // 4) ifTrue: [self halt].
	f close.
	swapBytes ifTrue: [Utilities informUser: 'Swapping bytes of foreign image...'
								during: [self reverseBytesInImage]].

	self initialize.
	bytesToShift _ 0 - oldBaseAddr.  "adjust pointers for zero base address"
	endOfMemory _ endOfMemory.
	self initializeCache: memoryLimit.
	Utilities informUser: 'Relocating object pointers...'
				during: [self initializeInterpreter: bytesToShift].
	checkAssertions _ false.