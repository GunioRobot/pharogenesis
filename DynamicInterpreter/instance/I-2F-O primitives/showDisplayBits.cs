showDisplayBits
	"Repaint the portion of the Smalltalk screen bounded by the affected rectangle. Used to synchronize the screen after a Bitblt to the Smalltalk Display object."

	| displayObj dispBits w h affectedRectL affectedRectR affectedRectT affectedRectB dispBitsIndex d |
	displayObj _ self splObj: TheDisplay.
	self targetForm = displayObj ifFalse: [^ nil].
	self success: ((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]).
	successFlag ifTrue: [
		dispBits _ self fetchPointer: 0 ofObject: displayObj.
		w _ self fetchInteger: 1 ofObject: displayObj.
		h _ self fetchInteger: 2 ofObject: displayObj.
		d _ self fetchInteger: 3 ofObject: displayObj.
	].
	successFlag ifTrue: [
		affectedRectL _ self affectedLeft.
		affectedRectR _ self affectedRight.
		affectedRectT _ self affectedTop.
		affectedRectB _ self affectedBottom.
		dispBitsIndex _ dispBits + BaseHeaderSize.  "index in memory byte array"
		self cCode: 'ioShowDisplay(dispBitsIndex, w, h, d, affectedRectL, affectedRectR, affectedRectT, affectedRectB)'.
	].