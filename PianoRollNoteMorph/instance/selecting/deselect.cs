deselect

	selected ifFalse: [^ self].
	self changed.
	selected _ false.
