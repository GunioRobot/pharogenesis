midiPlayLoop

	| mSecsPerStep tStart mSecs |
	mSecsPerStep _ 5.
	[done] whileFalse: [
		tStart _ Time millisecondClockValue.
		self processAllAtTick: ticksSinceStart asInteger.
		(Delay forMilliseconds: mSecsPerStep) wait.
		mSecs _ Time millisecondClockValue - tStart.
		mSecs < 0 ifTrue: [mSecs _ mSecsPerStep].  "clock wrap"
		ticksSinceStart _ ticksSinceStart + (mSecs asFloat / (1000.0 * secsPerTick))].
