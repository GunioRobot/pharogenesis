at: index put: aCharacter 

	aCharacter isCharacter ifFalse: [
		self error: 'MultiStrings only store (descendents of) Characters'.
	].
	self basicAt: index put: aCharacter asciiValue.
