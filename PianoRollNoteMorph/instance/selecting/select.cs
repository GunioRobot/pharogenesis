select

	selected ifTrue: [^ self].
	selected _ true.
	self changed