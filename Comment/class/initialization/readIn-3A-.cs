readIn: filename
	|f|
	f _ ReferenceStream fileNamed: filename.
	CommentsTable _ f next.
	f close.