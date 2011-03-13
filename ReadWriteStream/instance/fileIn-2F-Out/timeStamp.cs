timeStamp
	"Append the current time to the receiver."

	| aStream |
	aStream _ WriteStream on: (String new: 16).
	Smalltalk timeStamp: aStream.
	self command: 'H2'.
	self nextChunkPut: aStream contents printString.	"double quotes and !s"
	self command: '/H2'.
	self cr; cr