recordFontShapeEnd: fontId with: charId
	| font shape |
	self endShape.
	shape := FlashGlyphMorph withAll: currentShape contents reversed.
	shape lockChildren.
	currentShape resetToStart.
	font := fonts at: fontId ifAbsentPut:[Dictionary new].
	font at: charId put: shape.
	self doLog ifTrue:[log := Transcript].