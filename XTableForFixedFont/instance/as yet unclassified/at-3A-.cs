at: anInteger

	(anInteger < 1 or: [maxCode + 2 < anInteger]) ifTrue: [
		self error: 'subscript out of bounds'.
	].
	^(anInteger - 1) * width.
