putFile: file1 named: destinationFileName
	"Copy the contents of the existing fileStream into the file destinationFileName in this directory.  fileStream can be anywhere in the fileSystem."

	| file2 buffer |
	file1 binary.
	(file2 _ self newFileNamed: destinationFileName) ifNil: [^ false].
	file2 binary.
	buffer _ String new: 50000.
	[file1 atEnd] whileFalse:
		[file2 nextPutAll: (file1 nextInto: buffer)].
	file1 close.
	file2 close.
	^ true
