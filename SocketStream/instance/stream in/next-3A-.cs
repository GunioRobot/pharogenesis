next: anInteger
	"Answer anInteger bytes of data."
	[self atEnd not and: [self inStream size - self inStream position < anInteger]]
		whileTrue: [self receiveData].
	^self inStream next: anInteger