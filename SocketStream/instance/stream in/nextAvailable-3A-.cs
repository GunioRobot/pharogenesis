nextAvailable: howMany
	"Answer howMany bytes of data at most, otherwise answer as many as available."
	self inStream atEnd ifFalse: [^ self inStream next: howMany].
	self isDataAvailable ifTrue: [self receiveData].
	^self inStream next: howMany