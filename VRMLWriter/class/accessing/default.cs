default
	^Default isNil
		ifTrue:[Default := self new]
		ifFalse:[Default].