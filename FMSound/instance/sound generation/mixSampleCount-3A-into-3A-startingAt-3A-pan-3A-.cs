mixSampleCount: n into: aSoundBuffer startingAt: startIndex pan: pan
	"A simple implementation of Chowning's frequency-modulation synthesis technique. The center frequency is varied as the sound plays by changing the increment by which to step through the wave table."
	"FMSound majorScale play"
	"(FMSound pitch: 440.0 dur: 1.0 loudness: 200) play"

	| lastIndex i mySample sample channelIndex |
	<primitive: 177>
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

		index _ index + increment + ((modulation * (waveTable at: offsetIndex)) // 1000000).
		index > waveTableSize ifTrue: [
			index _ index - waveTableSize.
		].
		index < 1 ifTrue: [
			index _ index + waveTableSize.
		].
		offsetIndex _ offsetIndex + offsetIncrement.
		offsetIndex > waveTableSize ifTrue: [
			offsetIndex _ offsetIndex - waveTableSize.
		].
	].
	count _ count - n.
