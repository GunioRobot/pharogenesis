gcMin
	prevMsClock _ Time millisecondClockValue.
	prevFullGC _ vmParameters at: 8.
	prevDeltaFullGC _ 0.
	prevIncrGC _ vmParameters at: 10.
	prevDeltaIncrGC _ 0.
	^0