saveInstrument

	| name |
	name _ FillInTheBlank request: 'Instrument name?' translated.
	name isEmpty ifTrue: [^ self].
	AbstractSound soundNamed: name put: self makeLoopedSampledSound.
