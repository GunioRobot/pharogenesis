close
	"Close the stream."

	| bytes |
	byteStream closed 
		ifFalse: [
			bytes _ byteStream position.
			byteStream close]
		ifTrue: [bytes _ 'unknown'].
	^ bytes