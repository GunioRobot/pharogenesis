formFromStream: aBinaryStream
	"Answer a ColorForm stored on the given stream.  closes the stream"
	| reader readerClass form  |

	readerClass _ self withAllSubclasses
		detect: [:subclass | aBinaryStream reset. (subclass new on: aBinaryStream) understandsImageFormat]
		ifNone: [
			(aBinaryStream respondsTo: #close) ifTrue: [ aBinaryStream close ].
			^self error: 'image format not recognized'].
	reader _ readerClass new on: aBinaryStream reset.
	Cursor read showWhile: [
		form _ reader nextImage.
		reader close].
	^ form
