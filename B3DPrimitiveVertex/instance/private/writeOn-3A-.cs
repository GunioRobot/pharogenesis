writeOn: aStream
	aStream nextInt32Put: self basicSize.
	aStream nextWordsPutAll: self.