indexOfAscii: anInteger inString: aString startingAt: start
	"Trivial, non-primitive version"
	| stringSize |
	stringSize _ aString size.
	start to: stringSize do: [:pos |
		(aString at: pos) asInteger = anInteger ifTrue: [^ pos]].
	^ 0
