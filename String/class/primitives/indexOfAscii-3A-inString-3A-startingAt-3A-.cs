indexOfAscii: anInteger inString: aString startingAt: start

	| stringSize |
	<primitive: 'primitiveIndexOfAsciiInString' module: 'MiscPrimitivePlugin'>

	self var: #aCharacter declareC: 'int anInteger'.
	self var: #aString declareC: 'unsigned char *aString'.

	stringSize _ aString size.
	start to: stringSize do: [:pos |
		(aString at: pos) asciiValue = anInteger ifTrue: [^ pos]].

	^ 0
