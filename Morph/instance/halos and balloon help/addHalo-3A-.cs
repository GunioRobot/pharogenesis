addHalo: evt
	| halo prospectiveHaloClass |
	prospectiveHaloClass _ Smalltalk at: self classForHalo ifAbsent: [HaloMorph].
	halo _ prospectiveHaloClass new bounds: self worldBoundsForHalo.

	self world addMorphFront: halo.
	halo target: self.
	halo startStepping.
