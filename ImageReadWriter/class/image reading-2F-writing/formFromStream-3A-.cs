formFromStream: aBinaryStream
	"Answer a ColorForm stored on the given stream.  closes the stream"
	| reader readerClass form  |

	readerClass _ self withAllSubclasses
		detect: [:subclass | subclass understandsImageFormat: aBinaryStream]
		ifNone: [
			aBinaryStream close.
			^self error: 'image format not recognized'].
	reader _ readerClass new on: aBinaryStream reset.
	Cursor read showWhile: [
		form _ reader nextImage.
		reader close].
	^ form
