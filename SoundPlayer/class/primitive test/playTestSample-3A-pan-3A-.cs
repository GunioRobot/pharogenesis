playTestSample: s pan: pan
	"Append the given sample in the range [-32767..32767] to the output buffer, playing the output buffer when it is full. Used for testing only."

	| sample leftSample |
	BufferIndex >= Buffer size ifTrue: [
		"current buffer is full; play it"
		[self primSoundAvailableSpace > 0] whileFalse: [
			"wait for space to be available"
			(Delay forMilliseconds: 1) wait.
		].
		self primSoundPlaySamples: Buffer sampleCount from: Buffer startingAt: 1.
		Buffer primFill: 0.
		BufferIndex _ 1.
	].
	sample _ s.
	sample >  32767 ifTrue: [ sample _  32767 ]. 
	sample < -32767 ifTrue: [ sample _ -32767 ].

	Stereo ifTrue: [
		leftSample _ (sample * pan) // 1000.
		Buffer at: BufferIndex		put: sample - leftSample.
		Buffer at: BufferIndex + 1	put: leftSample.
	] ifFalse: [
		Buffer at: BufferIndex + 1 put: sample.
	].
	BufferIndex _ BufferIndex + 2.
