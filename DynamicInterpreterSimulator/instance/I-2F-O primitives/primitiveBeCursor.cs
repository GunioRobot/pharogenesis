primitiveBeCursor
	"Take note of the current cursor"
	| cursorObj bitsObj offsetObj ourCursor |
	cursorObj _ self stackTop.
	self success: ((self isPointers: cursorObj) and: [(self lengthOf: cursorObj) >= 4]).
	successFlag ifTrue:
		[bitsObj _ self fetchPointer: 0 ofObject: cursorObj.
		offsetObj _ self fetchPointer: 4 ofObject: cursorObj.
		ourCursor _ Cursor
			extent: (self fetchInteger: 1 ofObject: cursorObj)@(self fetchInteger: 2 ofObject: cursorObj)
			fromArray: ((1 to: 16) collect: [:i |
					((self fetchWord: i-1 ofObject: bitsObj) >> 16) bitAnd: 16rFFFF])
			offset: (self fetchInteger: 0 ofObject: offsetObj)@(self fetchInteger: 1 ofObject: offsetObj)].
	successFlag
		ifTrue: [ourCursor show]
		ifFalse: [self primitiveFail].