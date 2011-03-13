deepCopy
	"Don't want to copy the destForm (Display) or fonts in the TextStyle.  9/13/96 tk"

	| new |
	new _ self copy.
	new textStyle: textStyle copy.
	new destinationForm: destinationForm.
	new lines: lines copy.
	new text: text deepCopy.
	^ new