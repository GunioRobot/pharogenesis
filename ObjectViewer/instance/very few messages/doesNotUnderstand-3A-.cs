doesNotUnderstand: aMessage 
	"Check for change after sending aMessage"
	| returnValue newValue |
	recursionFlag ifTrue: [^ aMessage sentTo: tracedObject].
	recursionFlag _ true.
	returnValue _ aMessage sentTo: tracedObject.
	newValue _ valueBlock value.
	newValue = lastValue ifFalse:
		[changeBlock value.
		lastValue _ newValue].
	recursionFlag _ false.
	^ returnValue