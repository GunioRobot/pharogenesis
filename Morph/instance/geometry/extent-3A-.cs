extent: aPoint

	bounds extent = aPoint ifTrue: [^ self].
	self changed.
	bounds _ bounds topLeft extent: aPoint.
	self layoutChanged.
	self changed.
