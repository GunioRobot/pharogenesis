addTextOnNewLine: aString
	"Adds the specified string to the output window as a new line"

	| textLength |

	self setText: ((textMorph contents) , (Character cr asString) , aString) asText.

	textLength _ textMorph contents size + 1.

	self selectFrom: textLength to: textLength.
	self scrollSelectionIntoView.


