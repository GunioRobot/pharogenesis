isSaving: aBoolean

	isSaving = aBoolean ifTrue: [^self].
	isSaving _ aBoolean.
	self changed: #isSaving