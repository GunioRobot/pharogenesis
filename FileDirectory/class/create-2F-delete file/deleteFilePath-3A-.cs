deleteFilePath: fullPathToAFile
	"Delete the file after finding its directory"

	| dir |
	dir _ self on: (self dirPathFor: fullPathToAFile).
	dir deleteFileNamed: (self localNameFor: fullPathToAFile).
