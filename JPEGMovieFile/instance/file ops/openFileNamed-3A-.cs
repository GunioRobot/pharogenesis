openFileNamed: fileName
	"Open the JPEG movie file with the given name."

	file ifNotNil: [file finalize].
	file _ nil.
	(FileDirectory default fileExists: fileName) ifFalse: [^ self].
	file _ (FileStream readOnlyFileNamed: fileName) binary.
	self readHeader.
	currentFrameIndex _ 1.
