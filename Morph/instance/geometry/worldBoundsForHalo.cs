worldBoundsForHalo
	"Answer the rectangle to be used as the inner dimension of my halos.
	Allow for showing either bounds or fullBounds, and compensate for the optional bounds rectangle."

	| r |
	r _ (Preferences haloEnclosesFullBounds)
		ifFalse: [ self boundsIn: nil ]
		ifTrue: [ self fullBoundsInWorld ].
	Preferences showBoundsInHalo ifTrue: [ ^r outsetBy: 1 ].
	^r