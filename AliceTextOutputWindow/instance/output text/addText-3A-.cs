addText: aString
	"Adds the specified string to the output window"

	| textLength |

	self setText: ((textMorph contents) , aString) asText.

	textLength _ textMorph contents size + 1.

	self selectFrom: textLength to: textLength.
	self scrollSelectionIntoView.
