processMorphShapeFrom: data
	"Process a new morph shape"
	| id bounds1 bounds2 edgeOffset |
	"Read shape id and bounding box"
	id := data nextWord.
	bounds1 := data nextRect.
	bounds2 := data nextRect.
	edgeOffset := data nextULong. "edge offset"
	edgeOffset := edgeOffset + data position.
	"Start new shape definition"
	self recordMorphShapeStart: id srcBounds: bounds1 dstBounds: bounds2.
	"Read fill styles for this shape"
	self processMorphFillStylesFrom: data.
	"Read line styles for this shape"
	self processMorphLineStylesFrom: data.
	"Get number of bits for fill and line styles"
	data initBits.
	nFillBits := data nextBits: 4.
	nLineBits := data nextBits: 4.
	"Process all records in this shape definition"
	[self processShapeRecordFrom: data] whileTrue.
	self recordMorphBoundary: id.
	data position: edgeOffset.
	data initBits.
	nFillBits := data nextBits: 4.
	nLineBits := data nextBits: 4.
	[self processShapeRecordFrom: data] whileTrue.
	"And mark the end of this shape"
	self recordMorphShapeEnd: id.
	self recordShapeProperty: id length: data size.