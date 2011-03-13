cr 
	"Answer a CharacterBlock that specifies the current location of the mouse 
	relative to a carriage return stop condition that has just been 
	encountered. The ParagraphEditor convention is to denote selections by 
	CharacterBlocks, sometimes including the carriage return (cursor is at 
	the end) and sometimes not (cursor is in the middle of the text)."

	((characterIndex ~= nil
		and: [characterIndex > text size])
			or: [(line last = text size)
				and: [(destY + line lineHeight) < characterPoint y]])
		ifTrue:	["When off end of string, give data for next character"
				destY _ destY +  line lineHeight.
				baselineY _ line lineHeight.
				lastCharacter _ nil.
				characterPoint _ (nextLeftMargin ifNil: [leftMargin]) @ destY.
				lastIndex _ lastIndex + 1.
				self lastCharacterExtentSetX: 0.
				^ true].
		lastCharacter _ CR.
		characterPoint _ destX @ destY.
		self lastCharacterExtentSetX: rightMargin - destX.
		^true