fileIn: fullName
	"File in the entire contents of the file specified by the name provided"

	| ff |
	fullName ifNil: [^ Beeper beep].
	ff _ self readOnlyFileNamed: (GZipReadStream uncompressedFileName: fullName).
	ff fileIn.
