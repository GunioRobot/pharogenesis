nextPutAll: aString
	"Write all the characters of aString into the receiver's file.  2/12/96 sw"
	self primWrite: fileID from: aString startingAt: 1 count: aString size.
	^ aString