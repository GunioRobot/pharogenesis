compressFile
	"Compress the currently selected file"

	(directory readOnlyFileNamed: self fullName) compressFile.
	self updateFileList