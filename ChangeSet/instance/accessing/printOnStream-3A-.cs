printOnStream: aStream
	"2/7/96 sw: provide the receiver's name in the printout"
	super printOnStream: aStream.
	aStream print: ' named ', self name