nextLayer

	| i |
	layers size > 1 ifFalse: [^ self].
	i _ ((layers indexOf: visibleLayer form) \\ layers size) + 1.
	visibleLayer form: (layers at: i).
	self updatePreview.
