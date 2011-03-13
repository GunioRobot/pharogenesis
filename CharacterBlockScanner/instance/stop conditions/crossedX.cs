crossedX
	"Text display has wrapping. The scanner just found a character past the x 
	location of the cursor. We know that the cursor is pointing at a character 
	or before one."

	| leadingTab currentX |
	((characterPoint x <= (destX + ((lastCharacterExtent x) // 2)))
		or: [line last = lastIndex])
		ifTrue:	[lastCharacter _ (text at: lastIndex).
				characterPoint _ destX @ destY.
				^true].
	"Pointing past middle of a character, return the next character."
	lastIndex _ lastIndex + 1.
	lastCharacter _ text at: lastIndex.
	currentX _ destX + lastCharacterExtent x.
	lastCharacterExtent x: (font widthOf: lastCharacter).
	characterPoint _ currentX @ destY.

	"Yukky if next character is space or tab."
	(lastCharacter = Space and: [textStyle alignment = Justified])
		ifTrue:	[lastCharacterExtent x:
					(lastCharacterExtent x + 	(line justifiedPadFor: (spaceCount + 1))).
				^true].
	lastCharacter = Space
		ifTrue:
			["See tabForDisplay for illumination on the following awfulness."
			leadingTab _ true.
			(line first to: lastIndex - 1) do:
			[:index |
			(text at: index) ~= Tab
				ifTrue: [leadingTab _ false]].
			(textStyle alignment ~= Justified or: [leadingTab])
				ifTrue:	[lastCharacterExtent x: (textStyle nextTabXFrom: currentX
							leftMargin: leftMargin rightMargin: rightMargin) -
								currentX]
				ifFalse:	[lastCharacterExtent x:  (((currentX + (textStyle tabWidth -
								(line justifiedTabDeltaFor: spaceCount))) -
									currentX) max: 0)]].
	^ true
