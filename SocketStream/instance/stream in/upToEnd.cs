upToEnd
	"Answer a subcollection from the current access position through the last element of the receiver."
	| resultStream |
	resultStream _ WriteStream on: (self streamBuffer: 100).
	[resultStream nextPutAll: self inStream upToEnd.
	self atEnd not or: [self isDataAvailable]]
		whileTrue: [self receiveData].
	^resultStream contents