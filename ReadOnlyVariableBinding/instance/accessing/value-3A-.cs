value: aValue
	(AttemptToWriteReadOnlyGlobal signal: 'Cannot store into read-only bindings') == true ifTrue:[
		value _ aValue.
	].