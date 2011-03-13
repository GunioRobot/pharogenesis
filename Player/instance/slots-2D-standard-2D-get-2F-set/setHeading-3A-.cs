setHeading: aNumber

	0.0 = aNumber
		ifTrue: [
			1.0 = self getScaleFactor ifTrue: [
				costume isFlexMorph ifTrue: [costume removeFlexShell].
				^ self]]
		ifFalse: [
			costume isFlexMorph ifFalse: [costume addFlexShell]].
	costume rotationDegrees: aNumber.
