isJPEGMovieFile: fileName
	"Answer true if the file with the given name appears to be a JPEG movie file."

	| f tag |
	(FileDirectory default fileExists: fileName) ifFalse: [^ false].
	f _ (FileStream readOnlyFileNamed: fileName) binary.
	tag _ (f next: 10) asString.
	f close.
	^ tag = 'JPEG Movie'
