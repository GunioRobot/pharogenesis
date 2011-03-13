applyReverbTo: aSoundBuffer startingAt: startIndex count: n

	| delayedLeft delayedRight i tapGain j out |
	<primitive: 'primitiveApplyReverb' module:'SoundGenerationPlugin'>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #tapDelays declareC: 'int *tapDelays'.
	self var: #tapGains declareC: 'int *tapGains'.
	self var: #leftBuffer declareC: 'short int *leftBuffer'.
	self var: #rightBuffer declareC: 'short int *rightBuffer'.

	startIndex to: ((startIndex + n) - 1) do: [:sliceIndex |
		delayedLeft _ delayedRight _ 0.
		1 to: tapCount do: [:tapIndex |
			i _ bufferIndex - (tapDelays at: tapIndex).
			i < 1 ifTrue: [i _ i + bufferSize].  "wrap"
			tapGain _ tapGains at: tapIndex.
			delayedLeft _ delayedLeft + (tapGain * (leftBuffer at: i)).
			delayedRight _ delayedRight + (tapGain * (rightBuffer at: i))].

		"left channel"
		j _ (2 * sliceIndex) - 1.
		out _ (aSoundBuffer at: j) + (delayedLeft // ScaleFactor).
		out >  32767 ifTrue: [out _  32767].  "clipping!"
		out < -32767 ifTrue: [out _ -32767].  "clipping!"
		aSoundBuffer at: j put: out.
		leftBuffer at: bufferIndex put: out.

		"right channel"
		j _ j + 1.
		out _ (aSoundBuffer at: j) + (delayedRight // ScaleFactor).
		out >  32767 ifTrue: [out _  32767].  "clipping!"
		out < -32767 ifTrue: [out _ -32767].  "clipping!"
		aSoundBuffer at: j put: out.
		rightBuffer at: bufferIndex put: out.

		bufferIndex _ (bufferIndex \\ bufferSize) + 1].
