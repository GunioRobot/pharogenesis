compressFile
	"Compress the currently selected file"

	| f |
	f _ StandardFileStream
				readOnlyFileNamed: (directory fullNameFor: self fullName).
	f compressFile.
	self updateFileList