fromFileNamed: fileName
	"Read a Form or ColorForm from given file, using the first byte of the file to guess its format. If the desired depth is not nil, convert the resulting Form to the given depth. Currently handles three file formats: GIF, uncompressed BMP, and DisplayObject storeOn:. Return nil if the file could not be read or was of an unknown format."

	| f firstByte gifReader |
	f _ FileStream readOnlyFileNamed: fileName.
	firstByte _ f next.
	f close.
	firstByte = $G
		ifTrue: [
			gifReader _ Smalltalk gifReaderClass.
			gifReader ifNil:
				[^ self inform:
					'Sorry, there is no GIF reader available in the current system'].
			^ gifReader formFromFileNamed: fileName].
	firstByte = $B
		ifTrue: [^ self fromBMPFileNamed: fileName].
	firstByte asciiValue = 2
		ifTrue: [^ self newFromFileNamed: fileName].
	^ nil  "unknown format"
