processShapesFrom: data
	"Process a new shape"
	| id bounds |
	"Read shape id and bounding box"
	id _ data nextWord.
	bounds _ data nextRect.
	"Start new shape definition"
	self recordShapeStart: id bounds: bounds.
	"Read styles for this shape"
	self processShapeStylesFrom: data.
	"Get number of bits for fill and line styles"
	data initBits.
	nFillBits _ data nextBits: 4.
	nLineBits _ data nextBits: 4.
	"Process all records in this shape definition"
	[self processShapeRecordFrom: data] whileTrue.
	"And mark the end of this shape"
	self recordShapeEnd: id.
	self recordShapeProperty: id length: data size.