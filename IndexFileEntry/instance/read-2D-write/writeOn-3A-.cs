writeOn: aStream
	"Write a human-readable representation of myself on the given text stream."

	aStream
		nextPutAll: location printString; cr;
		nextPutAll: textLength printString; cr;
		nextPutAll: time printString; cr;
		nextPutAll: from; cr;
		nextPutAll: to; cr;
		nextPutAll: cc; cr;
		nextPutAll: subject; cr.
