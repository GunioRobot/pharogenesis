slideBy: inc
	submorphs isEmpty ifTrue: [^ self].
	offset _ offset + inc \\ self subBounds extent.
	self changed