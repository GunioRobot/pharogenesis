processGlyphsFrom: data
	| id bounds matrix |
	id := data nextWord.
	bounds := data nextRect.
	matrix := data nextMatrix.
	self recordTextStart: id bounds: bounds matrix: matrix.
	nGlyphBits := data nextByte.
	nAdvanceBits := data nextByte.
	log ifNotNil:[
		log	nextPutAll:'(nGlyphBits = '; 
			print: nGlyphBits; 
			nextPutAll:' nAdvanceBits = '; 
			print: nAdvanceBits;
			nextPutAll:') '.
		self flushLog].
	[self processGlyphRecordFrom: data] whileTrue.
	self recordTextEnd: id.