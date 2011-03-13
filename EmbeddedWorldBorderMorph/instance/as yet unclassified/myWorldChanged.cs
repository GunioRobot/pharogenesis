myWorldChanged
	| trans |
	trans _ self myTransformation.
	self changed.
	self layoutChanged.
	trans ifNotNil:[
		trans extentFromParent: self innerBounds extent.
		bounds _ bounds topLeft extent: trans extent + (borderWidth * 2).
	].
	self changed.
