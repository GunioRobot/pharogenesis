saveInstrument

	| name |
	name _ FillInTheBlank request: 'Instrument name?'.
	name isEmpty ifTrue: [^ self].
	AbstractSound soundNamed: name put: self makeLoopedSampledSound.
