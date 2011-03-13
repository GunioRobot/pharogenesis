recordFontShapeStart: fontId with: charId
	location := 0@0.
	self logShapes ifFalse:[log := nil].
	self beginShape.
	self recordSolidFill: 1 color: Color black.