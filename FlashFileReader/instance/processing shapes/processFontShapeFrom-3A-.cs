processFontShapeFrom: data
	data initBits.
	nFillBits _ data nextBits: 4.
	nLineBits _ data nextBits: 4.
	"Process all records in this shape definition"
	[self processShapeRecordFrom: data] whileTrue.