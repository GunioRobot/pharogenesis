samplesRemaining

	| samplesPlayed |
	mpegFile ifNil: [^ 0].
	self repeat ifTrue: [^ 1000000].
	samplesPlayed _ mpegFile audioGetSample: mpegStreamIndex.
	samplesPlayed > totalSamples ifTrue: [^ 0].
	^ totalSamples - samplesPlayed
