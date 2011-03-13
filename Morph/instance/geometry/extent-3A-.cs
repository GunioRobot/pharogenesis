extent: aPoint

	bounds extent = aPoint ifTrue: [^ self].
	self changed.
	bounds := (bounds topLeft extent: aPoint) rounded.
	self layoutChanged.
	self changed.
