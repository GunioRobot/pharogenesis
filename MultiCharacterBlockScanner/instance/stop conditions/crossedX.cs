crossedX
	"Text display has wrapping. The scanner just found a character past the x 
	location of the cursor. We know that the cursor is pointing at a character 
	or before one."

	| leadingTab currentX |
	characterIndex == nil ifFalse: [
		"If the last character of the last line is a space,
		and it crosses the right margin, then locating
		the character block after it is impossible without this hack."
		characterIndex > text size ifTrue: [
			lastIndex _ characterIndex.
			characterPoint _ (nextLeftMargin ifNil: [leftMargin]) @ (destY + line lineHeight).
			^true]].
	characterPoint x <= (destX + (lastCharacterExtent x // 2))
		ifTrue:	[lastCharacter _ (text at: lastIndex).
				characterPoint _ destX @ destY.
				^true].
	lastIndex >= line last 
		ifTrue:	[lastCharacter _ (text at: line last).
				characterPoint _ destX @ destY.
				^true].

	"Pointing past middle of a character, return the next character."
	lastIndex _ lastIndex + 1.
	lastCharacter _ text at: lastIndex.
	currentX _ destX + lastCharacterExtent x + kern.
	self lastCharacterExtentSetX: (font widthOf: lastCharacter).
	characterPoint _ currentX @ destY.
	lastCharacter = Space ifFalse: [^ true].

	"Yukky if next character is space or tab."
	alignment = Justified ifTrue:
		[self lastCharacterExtentSetX:
			(lastCharacterExtent x + 	(line justifiedPadFor: (spaceCount + 1))).
		^ true].

	true ifTrue: [^ true].
	"NOTE:  I find no value to the following code, and so have defeated it - DI"

	"See tabForDisplay for illumination on the following awfulness."
	leadingTab _ true.
	line first to: lastIndex - 1 do:
		[:index | (text at: index) ~= Tab ifTrue: [leadingTab _ false]].
	(alignment ~= Justified or: [leadingTab])
		ifTrue:	[self lastCharacterExtentSetX: (textStyle nextTabXFrom: currentX
					leftMargin: leftMargin rightMargin: rightMargin) -
						currentX]
		ifFalse:	[self lastCharacterExtentSetX:  (((currentX + (textStyle tabWidth -
						(line justifiedTabDeltaFor: spaceCount))) -
							currentX) max: 0)].
	^ true