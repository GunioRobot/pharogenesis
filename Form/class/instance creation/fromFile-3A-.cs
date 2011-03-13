fromFile: fileStream
	"Read a Form or ColorForm from given file, using the first byte of the file to guess its format. If the desired depth is not nil, convert the resulting Form to the given depth. Currently handles four file formats: GIF, uncompressed BMP, and both old and new DisplayObject writeOn: formats. Return nil if the file could not be read or was of an unknown format."

	| f firstByte result gifReader |
	f _ fileStream readOnly; binary.
	firstByte _ f next.
	firstByte = 1
		ifTrue: [result _ self new readFromOldFormat: f].
	firstByte = 2
		ifTrue: [result _ self new readFrom: f].
	firstByte = $B asciiValue
		ifTrue: [f skip: - 1. result _ self fromBMPFile: f].
	firstByte = $G asciiValue
		ifTrue: [
			gifReader _ Smalltalk gifReaderClass.
			gifReader ifNil: [
				f close.
				self inform:
					'Sorry, there is no GIF reader available in the current system'.
				^ nil].
			f position: 0.
			^ gifReader formFromFile: f].
	f close.

	result ifNil: [self error: 'unrecognized image file format'].
	^ result
