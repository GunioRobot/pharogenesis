processFontShapeFrom: data
	data initBits.
	nFillBits := data nextBits: 4.
	nLineBits := data nextBits: 4.
	"Process all records in this shape definition"
	[self processShapeRecordFrom: data] whileTrue.