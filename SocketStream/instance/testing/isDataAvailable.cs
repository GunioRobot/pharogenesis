isDataAvailable
	self inStream atEnd
		ifFalse: [^true].
	self socket dataAvailable
		ifTrue: [self receiveDataIfAvailable].
	^self socket dataAvailable