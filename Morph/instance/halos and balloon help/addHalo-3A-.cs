addHalo: evt
	| halo prospectiveHaloClass |
	prospectiveHaloClass := Smalltalk at: self haloClass ifAbsent: [HaloMorph].
	halo := prospectiveHaloClass new bounds: self worldBoundsForHalo.
	halo popUpFor: self event: evt.
	^halo