copyFileNamed: fileName1 toFileNamed: fileName2
	"Copy the contents of the existing file with the first name into a new file with the second name. Both files are assumed to be in this directory."
	"FileDirectory default copyFileNamed: 'todo.txt' toFileNamed: 'todocopy.txt'"

	| file1 file2 buffer |
	file1 _ (self readOnlyFileNamed: fileName1) binary.
	file2 _ (self newFileNamed: fileName2) binary.
	buffer _ String new: 50000.
	[file1 atEnd] whileFalse:
		[file2 nextPutAll: (file1 nextInto: buffer)].
	file1 close.
	file2 close.
