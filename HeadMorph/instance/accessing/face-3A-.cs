face: aFaceMorph
	face notNil ifTrue: [face delete].
	self addMorphFront: (face _ aFaceMorph)