extent: aPoint

	bounds extent = aPoint ifFalse: [
		self changed.
		bounds _ bounds topLeft extent: aPoint.
		self myWorldChanged.
	].
