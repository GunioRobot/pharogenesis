compressSolidFill: aFillStyle
	"Note: No terminators for simple colors"
	stream nextPut: $S. " 'S'olid fill"
	self storeColor: aFillStyle asColor on: stream.