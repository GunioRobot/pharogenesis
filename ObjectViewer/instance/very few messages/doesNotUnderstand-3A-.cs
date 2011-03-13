doesNotUnderstand: aMessage 
	"Check for change after sending aMessage"
	| returnValue newValue |
	recursionFlag ifTrue: [^ aMessage sentTo: tracedObject].
	recursionFlag := true.
	returnValue := aMessage sentTo: tracedObject.
	newValue := valueBlock value.
	newValue = lastValue ifFalse:
		[changeBlock value.
		lastValue := newValue].
	recursionFlag := false.
	^ returnValue