primitiveBeCursor
	"Set the cursor to the given shape. The Mac only supports 16x16 pixel cursors. Cursor offsets are handled by Smalltalk."

	| cursorObj maskBitsIndex maskObj bitsObj extentX extentY depth offsetObj offsetX offsetY cursorBitsIndex ourCursor |
	argumentCount = 0 ifTrue: [
		cursorObj _ self stackTop.
		maskBitsIndex _ nil].
	argumentCount = 1 ifTrue: [
		cursorObj _ self stackValue: 1.
		maskObj _ self stackTop].
	self success: (argumentCount < 2).

	self success: ((self isPointers: cursorObj) and: [(self lengthOf: cursorObj) >= 5]).
	successFlag ifTrue: [
		bitsObj _ self fetchPointer: 0 ofObject: cursorObj.
		extentX _ self fetchInteger: 1 ofObject: cursorObj.
		extentY _ self fetchInteger: 2 ofObject: cursorObj.
		depth _ self fetchInteger: 3 ofObject: cursorObj.
		offsetObj _ self fetchPointer: 4 ofObject: cursorObj].
		self success: ((self isPointers: offsetObj) and: [(self lengthOf: offsetObj) >= 2]).

	successFlag ifTrue: [
		offsetX _ self fetchInteger: 0 ofObject: offsetObj.
		offsetY _ self fetchInteger: 1 ofObject: offsetObj.
		self success: ((extentX = 16) and: [extentY = 16 and: [depth = 1]]).
		self success: ((offsetX >= -16) and: [offsetX <= 0]).
		self success: ((offsetY >= -16) and: [offsetY <= 0]).
		self success: ((self isWords: bitsObj) and: [(self lengthOf: bitsObj) = 16]).
		cursorBitsIndex _ bitsObj + BaseHeaderSize.
		self cCode: '' inSmalltalk:
			[ourCursor _ Cursor
				extent: extentX @ extentY
				fromArray: ((1 to: 16) collect: [:i |
					((self fetchWord: i-1 ofObject: bitsObj) >> 16) bitAnd: 16rFFFF])
				offset: offsetX  @ offsetY]].

	argumentCount = 1 ifTrue: [
		self success: ((self isPointers: maskObj) and: [(self lengthOf: maskObj) >= 5]).
		successFlag ifTrue: [
			bitsObj _ self fetchPointer: 0 ofObject: maskObj.
			extentX _ self fetchInteger: 1 ofObject: maskObj.
			extentY _ self fetchInteger: 2 ofObject: maskObj.
			depth _ self fetchInteger: 3 ofObject: maskObj].

		successFlag ifTrue: [
			self success: ((extentX = 16) and: [extentY = 16 and: [depth = 1]]).
			self success: ((self isWords: bitsObj) and: [(self lengthOf: bitsObj) = 16]).
			maskBitsIndex _ bitsObj + BaseHeaderSize]].

	successFlag ifTrue: [
		argumentCount = 0
			ifTrue: [self cCode: 'ioSetCursor(cursorBitsIndex, offsetX, offsetY)'
						inSmalltalk: [ourCursor show]]
			ifFalse: [self cCode: 'ioSetCursorWithMask(cursorBitsIndex, maskBitsIndex, offsetX, offsetY)'
						inSmalltalk: [ourCursor show]].
		self pop: argumentCount].
