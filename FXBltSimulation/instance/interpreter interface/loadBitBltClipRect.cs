loadBitBltClipRect
	"Load the clipping rectangle from a BitBlt oop."
	self inline: true.
	clipX _ self fetchIntOrFloat: BBClipXIndex ofObject: bitBltOop ifNil: 0.
	clipY _ self fetchIntOrFloat: BBClipYIndex ofObject: bitBltOop ifNil: 0.
	clipWidth _ self fetchIntOrFloat: BBClipWidthIndex ofObject: bitBltOop ifNil: destWidth.
	clipHeight _ self fetchIntOrFloat: BBClipHeightIndex ofObject: bitBltOop ifNil: destHeight.
	interpreterProxy failed ifTrue: [^ false  "non-integer value"].
	clipX < 0 ifTrue: [clipWidth _ clipWidth + clipX.  clipX _ 0].
	clipY < 0 ifTrue: [clipHeight _ clipHeight + clipY.  clipY _ 0].
	clipX+clipWidth > destWidth ifTrue: [clipWidth _ destWidth - clipX].
	clipY+clipHeight > destHeight ifTrue: [clipHeight _ destHeight - clipY].
	^true