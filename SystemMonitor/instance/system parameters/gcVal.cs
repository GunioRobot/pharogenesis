gcVal
	| ms fullGC incrGC deltaMs deltaFull deltaIncr max |
	ms _ Time millisecondClockValue.
	fullGC _ (vmParameters at: 8).
	incrGC _ (vmParameters at: 10).
	deltaMs _ ms - prevMsClock.
	deltaFull _ fullGC - prevFullGC.
	deltaIncr _ incrGC - prevIncrGC.
	prevMsClock _ ms.
	prevFullGC _ fullGC.
	prevIncrGC _ incrGC.
	prevDeltaFullGC _ prevDeltaFullGC + deltaFull / 2.
	prevDeltaIncrGC _ prevDeltaIncrGC + deltaIncr / 2.
	max _ deltaMs * 2.
	^Array
		with: (prevDeltaFullGC * 100 / max) asInteger
		with: (prevDeltaIncrGC * 100 / max) asInteger