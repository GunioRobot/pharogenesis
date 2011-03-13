canRecordWhilePlaying
	^ self
		valueOfFlag: #canRecordWhilePlaying
		ifAbsent: [false]