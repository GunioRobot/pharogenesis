= anObject
	^self class == anObject class and: [
		self byteArrayMap = anObject byteArrayMap ]