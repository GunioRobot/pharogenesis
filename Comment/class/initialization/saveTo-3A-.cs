saveTo: filename
	|f|
	f _ ReferenceStream fileNamed: filename.
	f nextPut: CommentsTable.
	f close.