testName
	| p |
	p := PhonemeRecordTest sampleOne.
	self assert: phoneme name = p name.
	phoneme name: 'p3'.
	self assert: phoneme name = 'p3'.