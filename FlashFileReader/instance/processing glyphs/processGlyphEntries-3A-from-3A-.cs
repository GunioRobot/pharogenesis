processGlyphEntries: nGlyphs from: data
	| index advance |
	data initBits.
	1 to: nGlyphs do:[:i|
		index _ data nextBits: nGlyphBits.
		advance _ data nextSignedBits: nAdvanceBits.
		self recordNextChar: index+1 advanceWidth: advance.
		log ifNotNil:[
			log nextPut:$(;print: index; space; print: advance; nextPut:$).
			self flushLog].
	].