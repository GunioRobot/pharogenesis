recordFontShapeStart: fontId with: charId
	location _ 0@0.
	self logShapes ifFalse:[log _ nil].
	self beginShape.
	self recordSolidFill: 1 color: Color black.