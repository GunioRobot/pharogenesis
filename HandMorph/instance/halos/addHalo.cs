addHalo
	| halo |
	halo _ HaloMorph new.
	self world addMorphFront: halo.
	halo target: argument.
	halo startStepping.
