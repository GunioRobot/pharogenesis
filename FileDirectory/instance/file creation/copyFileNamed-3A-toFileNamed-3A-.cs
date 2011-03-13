copyFileNamed: fileName1 toFileNamed: fileName2
	"FileDirectory default copyFileNamed: 'todo.txt'
						toFileNamed: 'todocopy.txt'"
	| file1 file2 buffer |
	file1 _ self readOnlyFileNamed: fileName1.
	file2 _ self newFileNamed: fileName2.
	buffer _ String new: 50000.
	[file1 atEnd] whileFalse:
		[file2 nextPutAll: (file1 nextInto: buffer)].
	file1 close.  file2 close