nextAvailable
	"Answer all the data currently available."
	self inStream atEnd ifFalse: [^ self inStream upToEnd].
	self isDataAvailable ifTrue: [self receiveData].
	^self inStream upToEnd