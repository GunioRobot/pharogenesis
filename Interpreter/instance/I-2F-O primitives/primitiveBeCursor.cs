primitiveBeCursor
	"Set the cursor to the given shape. The Mac only supports 16x16 pixel cursors. Cursor offsets are handled by Smalltalk."

	| cursorObj bitsObj extentX extentY offsetObj offsetX offsetY cursorBitsIndex |
	cursorObj _ self stackTop.
	self success: ((self isPointers: cursorObj) and: [(self lengthOf: cursorObj) >= 5]).
	successFlag ifTrue: [
		bitsObj _ self fetchPointer: 0 ofObject: cursorObj.
		extentX _ self fetchInteger: 1 ofObject: cursorObj.
		extentY _ self fetchInteger: 2 ofObject: cursorObj.
		offsetObj _ self fetchPointer: 4 ofObject: cursorObj.
		self success: ((self isPointers: offsetObj) and: [(self lengthOf: offsetObj) >= 2]).
	].
	successFlag ifTrue: [
		offsetX _ self fetchInteger: 0 ofObject: offsetObj.
		offsetY _ self fetchInteger: 1 ofObject: offsetObj.
		self success: ((extentX = 16) and: [extentY = 16]).
		self success: ((offsetX >= -16) and: [offsetX <= 0]).
		self success: ((offsetY >= -16) and: [offsetY <= 0]).
		self success: ((self isWords: bitsObj) and: [(self lengthOf: bitsObj) = 16]).
		cursorBitsIndex _ bitsObj + BaseHeaderSize.
	].
	successFlag ifTrue: [
		self cCode: 'ioSetCursor(cursorBitsIndex, offsetX, offsetY)'.
	].