parseFirstMarker

	self next = 16rFF ifFalse: [self error: 'JFIF marker expected'].
	self next = 16rD8 ifFalse: [self error: 'SOI marker expected'].
	self parseStartOfInput.
