recordFontShapeEnd: fontId with: charId
	| font shape |
	self endShape.
	shape _ FlashGlyphMorph withAll: currentShape contents reversed.
	shape lockChildren.
	currentShape resetToStart.
	font _ fonts at: fontId ifAbsentPut:[Dictionary new].
	font at: charId put: shape.
	self doLog ifTrue:[log _ Transcript].