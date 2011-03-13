setScaleFactor: aNumber

	1.0 = aNumber
		ifTrue: [
			0.0 = self getHeading ifTrue: [
				costume isFlexMorph ifTrue: [costume removeFlexShell].
				^ self]]
		ifFalse: [
			costume isFlexMorph ifFalse: [costume addFlexShell]].
	costume scale: (aNumber asFloat max: 0.125).
