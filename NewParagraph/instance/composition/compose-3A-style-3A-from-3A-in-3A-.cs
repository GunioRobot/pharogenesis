compose: t style: ts from: startingIndex in: textContainer
	text _ t.
	textStyle _ ts.
	firstCharacterIndex _ startingIndex.
	offsetToEnd _ text size - firstCharacterIndex.
	container _ textContainer.
	self composeAll