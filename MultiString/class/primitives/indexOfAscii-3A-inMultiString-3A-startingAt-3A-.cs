indexOfAscii: anInteger inMultiString: aString startingAt: start

	| stringSize |

	self var: #aCharacter declareC: 'int anInteger'.
	self var: #aString declareC: 'unsigned int *aString'.

	stringSize _ aString size.
	start to: stringSize do: [:pos |
		(aString at: pos) asciiValue = anInteger ifTrue: [^ pos]].

	^ 0
