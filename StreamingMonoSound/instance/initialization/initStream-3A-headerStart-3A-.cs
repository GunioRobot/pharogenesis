initStream: aStream headerStart: anInteger
	"Initialize for streaming from the given stream. The audio file header starts at the given stream position."

	stream _ aStream.
	volume _ 1.0.
	repeat _ false.
	headerStart _ anInteger.
	self reset.
