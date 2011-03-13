addHaloFor: aHand
	| halo prospectiveHaloClass |
	prospectiveHaloClass _ Smalltalk at: self haloClass ifAbsent: [HaloMorph].
	halo _ prospectiveHaloClass new bounds: self worldBoundsForHalo.
	halo popUpFor: self hand: aHand.