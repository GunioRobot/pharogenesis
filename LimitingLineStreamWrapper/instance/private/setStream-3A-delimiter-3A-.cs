setStream: aStream delimiter: aString

	stream _ aStream.
	line _ stream nextLine.
	self delimiter: aString.	"sets position"
