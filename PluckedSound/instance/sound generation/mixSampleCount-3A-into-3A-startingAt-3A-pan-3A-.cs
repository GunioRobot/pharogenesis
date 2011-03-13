mixSampleCount: n into: aSoundBuffer startingAt: startIndex pan: pan
	"The Karplus-Strong plucked string algorithm: start with a buffer full of random noise and repeatedly play the contents of that buffer while averaging adjacent samples. High harmonics damp out more quickly, transfering their energy to lower ones. The length of the buffer corresponds to the length of the string. It may be out of tune for higher pitches because the buffer length must be an integral number of samples and the nearest integer may not result in the exact pitch desired."
	"(PluckedSound pitch: 220.0 dur: 3.0 loudness: 1000) play"

	| lastIndex thisIndex i nextIndex mySample channelIndex sample |
	<primitive: 178>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #ring declareC: 'short int *ring'.

	lastIndex _ (startIndex + n) - 1.
	thisIndex _ ringIndx.
	startIndex to: lastIndex do: [ :i |
		nextIndex _ (thisIndex \\ ringSize) + 1.
		mySample _ ((ring at: thisIndex) + (ring at: nextIndex)) // 2.
		ring at: thisIndex put: mySample.
		thisIndex _ nextIndex.

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
	].
	ringIndx _ nextIndex.
	count _ count - n.
