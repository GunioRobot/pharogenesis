deepCopy
	"Don't want to copy the container (etc) or fonts in the TextStyle."
	| new |
	new _ self copy.
	new textStyle: textStyle copy
		lines: lines copy
		text: text deepCopy.
	^ new