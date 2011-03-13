primitiveShowDisplayRect
	"Force the given rectangular section of the Display to be copied to the screen."

	| bottom top right left displayObj dispBits w h d dispBitsPtr |
	bottom	_ self stackIntegerValue: 0.
	top		_ self stackIntegerValue: 1.
	right	_ self stackIntegerValue: 2.
	left		_ self stackIntegerValue: 3.
	displayObj _ self splObj: TheDisplay.
	self success: ((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]).
	successFlag ifTrue: [
		dispBits _ self fetchPointer: 0 ofObject: displayObj.
		w _ self fetchInteger: 1 ofObject: displayObj.
		h _ self fetchInteger: 2 ofObject: displayObj.
		d _ self fetchInteger: 3 ofObject: displayObj].
	left < 0 ifTrue: [left _ 0].
	right > w ifTrue: [right _ w].
	top < 0 ifTrue: [top _ 0].
	bottom > h ifTrue: [bottom _ h].
	self success: ((left <= right) and: [top <= bottom]).
	successFlag ifTrue: [
		dispBitsPtr _ dispBits + BaseHeaderSize.
		self cCode: 'ioShowDisplay(dispBitsPtr, w, h, d, left, right, top, bottom)'].
	successFlag ifTrue: [self pop: 4].  "pop left, right, top, bottom; leave rcvr on stack"
