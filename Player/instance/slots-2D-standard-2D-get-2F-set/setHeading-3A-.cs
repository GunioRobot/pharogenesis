setHeading: newHeading
	| aCostume |
	aCostume _ self costume.
	newHeading = 0.0
		ifTrue: 
			[self getScaleFactor = 1.0 ifTrue:
				[aCostume isFlexMorph ifTrue:
					[aCostume rotationDegrees: newHeading.
					aCostume removeFlexShell].
				^ self]]
		ifFalse:
			[aCostume isFlexMorph ifFalse: [aCostume addFlexShell]].
	self costume rotationDegrees: newHeading.
