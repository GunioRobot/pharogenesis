timeStamp
	"Append the current time to the receiver as a String."
	self nextChunkPut:	"double string quotes and !s"
		(String streamContents: [:s | SmalltalkImage current timeStamp: s]) printString.
	self cr