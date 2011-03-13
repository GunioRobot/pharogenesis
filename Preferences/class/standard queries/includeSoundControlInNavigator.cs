includeSoundControlInNavigator
	^ self
		valueOfFlag: #includeSoundControlInNavigator
		ifAbsent: [false]