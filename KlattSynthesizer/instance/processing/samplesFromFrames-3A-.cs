samplesFromFrames: aCollection
	| buffer index |
	buffer := SoundBuffer newMonoSampleCount: aCollection size * samplesPerFrame.
	index := 1.
	aCollection do: [ :each |
		self synthesizeFrame: each into: buffer startingAt: index.
		index := samplesPerFrame + index].
	^ buffer