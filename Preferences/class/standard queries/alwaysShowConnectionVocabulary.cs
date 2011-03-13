alwaysShowConnectionVocabulary
	^ self
		valueOfFlag: #alwaysShowConnectionVocabulary
		ifAbsent: [false]