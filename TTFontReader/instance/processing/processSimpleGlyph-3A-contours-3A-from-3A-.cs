processSimpleGlyph: glyph contours: nContours from: entry

	| endPts  nPts iLength flags |
	endPts _ Array new: nContours.
	1 to: nContours do:[:i| endPts at: i put: entry nextUShort].
	glyph initializeContours: nContours with: endPts.
	nPts _ endPts last + 1.
	iLength _ entry nextUShort. "instruction length"
	entry skip: iLength.
	flags _ self getGlyphFlagsFrom: entry size: nPts.
	self readGlyphXCoords: entry glyph: glyph nContours: nContours flags: flags endPoints: endPts.
	self readGlyphYCoords: entry glyph: glyph nContours: nContours flags: flags endPoints: endPts.
	glyph buildContours.