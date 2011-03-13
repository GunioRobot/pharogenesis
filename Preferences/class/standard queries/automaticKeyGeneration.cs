automaticKeyGeneration
	^ self
		valueOfFlag: #automaticKeyGeneration
		ifAbsent: [false]