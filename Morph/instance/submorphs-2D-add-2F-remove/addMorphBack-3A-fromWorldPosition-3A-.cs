addMorphBack: aMorph fromWorldPosition: wp

	self addMorphBack: aMorph.
	aMorph position: (self transformFromWorld transform: wp)