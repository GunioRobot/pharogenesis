fromBinaryStream: aBinaryStream
	"Read a Form or ColorForm from given file, using the first byte of the file to guess its format. Currently handles: GIF, uncompressed BMP, and both old and new DisplayObject writeOn: formats, JPEG, and PCX. Return nil if the file could not be read or was of an unrecognized format."

	| firstByte |
	aBinaryStream binary.
	firstByte _ aBinaryStream next.
	firstByte = 1 ifTrue: [
		"old Squeakform format"
		^ self new readFromOldFormat: aBinaryStream].
	firstByte = 2 ifTrue: [
		"new Squeak form format"
		^ self new readFrom: aBinaryStream].
	firstByte = $B asciiValue ifTrue: [
		"BMP format"
		aBinaryStream skip: - 1.
		^ self fromBMPFile: aBinaryStream].

	"Try for JPG, GIF, or PCX..."
	"Note: The following call closes the stream."
	^ Smalltalk imageReaderClass formFromStream: aBinaryStream
