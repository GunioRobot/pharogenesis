testDistanceToPhoneme
	| p distance |
	p := PhonemeRecordTest sampleTwo.
	distance := phoneme distanceToPhoneme: p.
	self assert: distance > 0.
	distance := phoneme distanceToPhoneme: phoneme.
	self assert: distance = 0.