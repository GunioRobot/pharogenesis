addMorphFront: aMorph fromWorldPosition: wp

	self addMorphFront: aMorph.
	aMorph position: (self transformFromWorld transform: wp)