verbatim: aString
	"A copy of nextPutAll that can be called knowing it wont call nextPut: "
	self primWrite: fileID from: aString startingAt: 1 count: aString size.
	^ aString