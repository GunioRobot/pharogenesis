textColor: aColor

	color = aColor ifTrue: [^ self].
	color _ aColor.
	self changed.
