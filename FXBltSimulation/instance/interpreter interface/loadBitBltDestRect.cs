loadBitBltDestRect
	"Load the destination rectangle from a BitBlt oop"
	self inline: true.
	destX _ self fetchIntOrFloat: BBDestXIndex ofObject: bitBltOop ifNil: 0.
	destY _ self fetchIntOrFloat: BBDestYIndex ofObject: bitBltOop ifNil: 0.
	width _ self fetchIntOrFloat: BBWidthIndex ofObject: bitBltOop ifNil: destWidth.
	height _ self fetchIntOrFloat: BBHeightIndex ofObject: bitBltOop ifNil: destHeight.
	^interpreterProxy failed not