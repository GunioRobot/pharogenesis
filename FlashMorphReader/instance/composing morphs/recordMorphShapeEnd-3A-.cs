recordMorphShapeEnd: id
	| startShape endShape morphShape |
	startShape _ shapes at: id.
	self recordShapeEnd: id.
	endShape _ shapes at: id.
	morphShape _ FlashMorphingMorph from: startShape to: endShape.
	morphShape id: id.
	morphShape stepTime: stepTime.
	shapes at: id put: morphShape.
	morphedLineStyles _ morphedFillStyles _ nil.