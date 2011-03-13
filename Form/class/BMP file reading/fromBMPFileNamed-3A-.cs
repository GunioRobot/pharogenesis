fromBMPFileNamed: fileName
	"Form fromBMPFileNamed: 'FulS.bmp'"

	| fileStream result |
	fileStream _ (FileStream readOnlyFileNamed: fileName) binary.
	result _ self fromBMPFile: fileStream.
	fileStream close.
	^ result
