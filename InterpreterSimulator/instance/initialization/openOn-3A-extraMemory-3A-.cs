openOn: fileName extraMemory: extraBytes
	"InterpreterSimulator new openOn: 'clone.im' extraMemory: 100000"

	| f version headerSize count oldBaseAddr bytesToShift swapBytes |
	"open image file and read the header"
	f _ FileStream readOnlyFileNamed: fileName.
	imageName _ f fullName.
	f binary.
	version _ self nextLongFrom: f.  "current version: 16r1966 (=6502)"
	(self readableFormat: version)
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
	memoryLimit _ endOfMemory + extraBytes.

	"read in the image in bulk, then swap the bytes if necessary"
	f position: headerSize.
	memory _ Bitmap new: memoryLimit // 4.
	count _ f readInto: memory startingAt: 1 count: endOfMemory // 4.
	count ~= (endOfMemory // 4) ifTrue: [self halt].
	f close.
	swapBytes ifTrue: [Utilities informUser: 'Swapping bytes of foreign image...'
								during: [self reverseBytesInImage]].

	self initialize.
	bytesToShift _ 0 - oldBaseAddr.  "adjust pointers for zero base address"
	endOfMemory _ endOfMemory.
	Utilities informUser: 'Relocating object pointers...'
				during: [self initializeInterpreter: bytesToShift].
