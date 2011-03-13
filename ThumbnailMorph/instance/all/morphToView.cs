morphToView

	objectToView ifNil: [^ nil].
	^ objectToView isMorph
		ifTrue:
			[objectToView]
		ifFalse:
			[objectToView costume]
