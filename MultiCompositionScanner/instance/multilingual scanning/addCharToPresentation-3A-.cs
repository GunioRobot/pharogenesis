addCharToPresentation: char

	presentation nextPut: char.
	lastWidth _ self widthOf: char inFont: font.
	destX _ destX + lastWidth.
