mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play a collection of sounds in sequence."

	| finalIndex i remaining count rate |
	self currentSound isNil ifTrue: [^ self].  "already done"
	self startTime > Time millisecondClockValue ifTrue: [^ self].
	rate _ self samplingRate.
	finalIndex _ (startIndex + n) - 1.
	i _ startIndex.
	[i <= finalIndex] whileTrue: [
		[self currentSound isNil ifTrue: [^ self].
		(remaining _ self currentSound samplesRemaining) <= 0]
			whileTrue: [self currentSound: self nextSound].
		count _ (finalIndex - i) + 1.
		remaining < count ifTrue: [count _ remaining].
		self currentSound mixSampleCount: count into: aSoundBuffer startingAt: i leftVol: leftVol rightVol: rightVol.
		i _ i + count]