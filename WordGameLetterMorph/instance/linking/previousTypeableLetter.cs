previousTypeableLetter

	predecessor ifNil: [^ self].
	predecessor isBlank ifTrue: [^ predecessor previousTypeableLetter].
	^ predecessor