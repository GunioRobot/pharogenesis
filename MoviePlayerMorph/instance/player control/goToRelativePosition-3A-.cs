goToRelativePosition: newPos

	movieFile ifNotNil: [^ self].
	self goToPage: ((newPos*frameCount) asInteger min: frameCount max: 1).
