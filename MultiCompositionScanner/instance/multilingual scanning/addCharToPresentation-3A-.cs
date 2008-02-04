addCharToPresentation: char

	presentation nextPut: char.
	lastWidth := self widthOf: char inFont: font.
	destX := destX + lastWidth.
