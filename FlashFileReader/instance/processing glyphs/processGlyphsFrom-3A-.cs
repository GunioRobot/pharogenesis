processGlyphsFrom: data
	| id bounds matrix |
	id _ data nextWord.
	bounds _ data nextRect.
	matrix _ data nextMatrix.
	self recordTextStart: id bounds: bounds matrix: matrix.
	nGlyphBits _ data nextByte.
	nAdvanceBits _ data nextByte.
	log ifNotNil:[
		log	nextPutAll:'(nGlyphBits = '; 
			print: nGlyphBits; 
			nextPutAll:' nAdvanceBits = '; 
			print: nAdvanceBits;
			nextPutAll:') '.
		self flushLog].
	[self processGlyphRecordFrom: data] whileTrue.
	self recordTextEnd: id.