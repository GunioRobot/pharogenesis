getSelectedFile

	directory ifNil: [^nil].
	fileName ifNil: [^nil].
	^ directory oldFileNamed: fileName
