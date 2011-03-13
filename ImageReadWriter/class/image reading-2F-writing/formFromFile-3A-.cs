formFromFile: fileStream
	"Answer a ColorForm stored on the file."

	| reader form |
	reader _ self on: fileStream.
	Cursor read showWhile: [
		form _ reader nextImage.
		reader close].
	^ form
