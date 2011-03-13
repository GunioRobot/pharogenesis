read
	| phoneme time |
	time := 0.
	[stream skipSeparators; atEnd]
		whileFalse: [phoneme := self nextPhoneme.
					currentDuration := self defaultDurationFor: phoneme.
					stream peek = $< ifTrue: [self readPitchAndDuration].
					f0Contour at: time + (currentDuration / 2.0 min: 0.1) put: currentPitch.
					time := time + currentDuration.
					f0Contour at: time put: currentPitch.
					events add: (PhoneticEvent new phoneme: phoneme; duration: currentDuration; loudness: 1.0)].
	self addPitches