addLast: aValue
	top = self basicSize ifTrue: [self grow].
	top := top + 1.
	^ self at: top put: aValue