addMorphCentered: aMorph

	self addMorphFront: aMorph.
	aMorph position: bounds center - (aMorph extent // 2)