samplesFromFrames: aCollection
	| buffer index |
	buffer _ SoundBuffer newMonoSampleCount: aCollection size * samplesPerFrame.
	index _ 1.
	aCollection do: [ :each |
		self synthesizeFrame: each into: buffer startingAt: index.
		index _ samplesPerFrame + index].
	^ buffer