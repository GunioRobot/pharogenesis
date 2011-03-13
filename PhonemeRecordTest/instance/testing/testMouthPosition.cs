testMouthPosition
	| p |
	p := PhonemeRecordTest sampleOne.
	self assert: phoneme mouthPosition = p mouthPosition.
	phoneme mouthPosition: 3.
	self assert: phoneme mouthPosition = 3.