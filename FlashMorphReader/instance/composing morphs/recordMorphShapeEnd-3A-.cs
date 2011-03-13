recordMorphShapeEnd: id
	| startShape endShape morphShape |
	startShape := shapes at: id.
	self recordShapeEnd: id.
	endShape := shapes at: id.
	morphShape := FlashMorphingMorph from: startShape to: endShape.
	morphShape id: id.
	morphShape stepTime: stepTime.
	shapes at: id put: morphShape.
	morphedLineStyles := morphedFillStyles := nil.