fromBMPFileNamed: fileName
	"Form fromBMPFileNamed: 'FulS.bmp'"

	| fileStream result |
	fileStream _ (FileStream oldFileNamed: fileName) binary.
	result _ self fromBMPFile: fileStream.
	fileStream close.
	^ result
