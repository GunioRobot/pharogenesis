prevLayer

	| i |
	layers size <= 1 ifTrue: [^ self].
	i _ (layers indexOf: visibleLayer form) - 1.
	i < 1 ifTrue: [i _ layers size].
	visibleLayer form: (layers at: i).
	self updatePreview.
