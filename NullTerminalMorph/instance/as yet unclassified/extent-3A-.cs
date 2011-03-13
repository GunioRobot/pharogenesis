extent: newExtent

	| aPoint |
	aPoint _ 50@50.
	bounds extent = aPoint ifFalse: [
		self changed.
		bounds _ bounds topLeft extent: aPoint.
		self layoutChanged.
		self changed
	].
	eventEncoder sendViewExtent: newExtent