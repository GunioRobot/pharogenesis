processGlyphDataTable: entry offsets: offsetArray
	"Read the actual glyph data from the font.
	offsetArray contains the start offsets in the data for each glyph."
	| initialOffset glyph nextOffset glyphLength glyphOffset nContours origin corner |
	initialOffset _ entry offset.
	glyphs _ Array new: nGlyphs.
	1 to: nGlyphs do:[:i | 
		glyphs at: i put: (TTGlyph new glyphIndex: i-1)].
	'Reading glyph data' 
		displayProgressAt: Sensor cursorPoint
		from: 1 to: nGlyphs during:[:bar|

	1 to: nGlyphs do:[:glyphIndex |
		bar value: glyphIndex.
		glyph _ glyphs at: glyphIndex.
		glyphOffset _ offsetArray at: glyphIndex.
		nextOffset _ offsetArray at: glyphIndex+1.
		glyphLength _ nextOffset - glyphOffset.
		glyphLength = 0 ifFalse:[
			entry offset: initialOffset + glyphOffset.
			nContours _ entry nextShort.
			origin _ entry nextShort @ entry nextShort.
			corner _ entry nextShort @ entry nextShort.
			glyph bounds: (origin corner: corner).
			nContours >= 0 ifTrue:[
				self processSimpleGlyph: glyph contours: nContours from: entry
			] ifFalse:[
				glyph _ self processCompositeGlyph: glyph contours: nContours from: entry.
				glyphs at: glyphIndex put: glyph]]]
	].