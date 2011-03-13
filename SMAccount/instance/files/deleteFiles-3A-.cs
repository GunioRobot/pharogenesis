deleteFiles: fileNames
	"Delete all fileNames from the uploads directory."

	| dir |
	dir := self uploadsDirectory.
	fileNames do: [:fn | dir deleteFileNamed: fn]
