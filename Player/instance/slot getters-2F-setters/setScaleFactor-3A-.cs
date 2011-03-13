setScaleFactor: aNumber
	"Set the scale factor to be the given value"

	| aCostume |
	aCostume _ self costume.
	1.0 = aNumber
		ifTrue:
			[0.0 = self getHeading ifTrue:
				[aCostume isFlexMorph ifTrue: [aCostume removeFlexShell].
				^ self]]
		ifFalse:
			[aCostume isFlexMorph ifFalse: [aCostume addFlexShell]].
	costume scale: (aNumber asFloat max: 0.125)