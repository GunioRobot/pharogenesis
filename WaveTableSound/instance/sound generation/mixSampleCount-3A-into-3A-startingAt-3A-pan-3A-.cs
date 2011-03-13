mixSampleCount: n into: aSoundBuffer startingAt: startIndex pan: pan
	"Play samples from a wave table by stepping a fixed amount throught the table on every sample. The decay parameter may be used to make the sound fade away, but its default value of 1.0 produces a sustained sound, like a flute. The abrupt start and stops of this sound result in transient clicks; it would benefit greatly from a simple attack-sustain-decay envelope."
	"(WaveTableSound pitch: 440.0 dur: 1.0 loudness: 200) play"

	| lastIndex i mySample channelIndex sample |
	<primitive: 176>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #waveTable declareC: 'short int *waveTable'.

	lastIndex _ (startIndex + n) - 1.
	startIndex to: lastIndex do: [ :i |
		mySample _ (amplitude * (waveTable at: index)) // 1000.
		pan > 0 ifTrue: [
			channelIndex _ 2 * i.
			sample _ (aSoundBuffer at: channelIndex) + ((mySample * pan) // 1000).
			sample >  32767 ifTrue: [ sample _  32767 ].  "clipping!"
			sample < -32767 ifTrue: [ sample _ -32767 ].  "clipping!"
			aSoundBuffer at: channelIndex put: sample.
		].
		pan < 1000 ifTrue: [
			channelIndex _ (2 * i) - 1.
			sample _ (aSoundBuffer at: channelIndex) + ((mySample * (1000 - pan)) // 1000).
			sample >  32767 ifTrue: [ sample _  32767 ].  "clipping!"
			sample < -32767 ifTrue: [ sample _ -32767 ].  "clipping!"
			aSoundBuffer at: channelIndex put: sample.
		].

		index _ index + increment.
		index > waveTableSize ifTrue: [
			index _ index - waveTableSize.
		].
	].
	count _ count - n.
