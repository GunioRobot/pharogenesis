formFromFileNamed: fileName
	"Answer a ColorForm stored on the file with the given name."

	| reader form |
	reader _ self on: (FileStream oldFileNamed: fileName).
	Cursor read showWhile: [
		form _ reader nextImage.
		reader close].
	^ form
