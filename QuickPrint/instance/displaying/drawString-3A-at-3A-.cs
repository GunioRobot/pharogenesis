drawString: aString at: aPoint
	"Draw the given string."

	destX _ aPoint x asInteger.
	destY _ aPoint y asInteger.
	self scanCharactersFrom: 1 to: aString size in: aString
		rightX: clipX + clipWidth + font maxWidth
		stopConditions: stopConditions
		displaying: true