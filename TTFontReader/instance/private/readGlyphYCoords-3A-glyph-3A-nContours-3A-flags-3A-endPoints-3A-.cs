readGlyphYCoords:entry glyph: glyph nContours: nContours flags: flags endPoints: endPts
	"Read the y coordinates for the given glyph from the font file."
	| startPoint endPoint flagBits yValue contour ttPoint |
	startPoint _ 1.
	1 to: nContours do:[:i|
		contour _ glyph contours at: i.
		"Get the end point"
		endPoint _ (endPts at: i) + 1.
		"Store number of points"
		startPoint to: endPoint do:[:j|
			ttPoint _ contour points at: (j - startPoint + 1).
			flagBits _ flags at: j.
			"Check if this value one or two byte encoded"
			(flagBits bitAnd: 4) = 4 ifTrue:[ "one byte"
				yValue _ entry nextByte.
				yValue _ (flagBits bitAnd: 32)=32 ifTrue:[yValue] ifFalse:[yValue negated].
				ttPoint y: yValue.
			] ifFalse:[ "two byte"
				(flagBits bitAnd: 32) = 32 ifTrue:[ ttPoint y: 0 ]
				ifFalse:[
					yValue _ entry nextShort.
					ttPoint y: yValue]]].
		startPoint _ endPoint + 1]