close
	"Close the stream."

	| bytes |
	bytes _ byteStream position.
	byteStream close.
	^ bytes