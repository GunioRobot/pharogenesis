nextTypeableLetter

	successor ifNil: [^ self].
	successor isBlank ifTrue: [^ successor nextTypeableLetter].
	^ successor