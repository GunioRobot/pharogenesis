selectNewCamera: aCameraString
	aCameraString ifNotNil: [
		self scene defaultCamera: (self scene cameras at: aCameraString) copy.
		self updateUpVectorForCamera: self scene defaultCamera.
		self changed.]