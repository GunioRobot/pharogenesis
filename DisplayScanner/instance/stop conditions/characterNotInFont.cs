characterNotInFont
	"See the note in CharacterScanner>>characterNotInFont.
	All fonts have an illegal character to be used when a character is not 
	within the font's legal range. When characters out of ranged are 
	encountered in scanning text, then this special character indicates the 
	appropriate behavior. The character is usually treated as a unary 
	message understood by a subclass of CharacterScanner."

	| illegalAsciiString saveIndex stopCondition lastPos |
	saveIndex _ lastIndex.
	lastPos _ destX @ destY.
	illegalAsciiString _ String with: (font maxAscii + 1) asCharacter.
	stopCondition _ self scanCharactersFrom: 1 to: 1
			in: illegalAsciiString
			rightX: rightMargin stopConditions: stopConditions
			kern: kern.
	font displayString: illegalAsciiString 
			on: bitBlt from: 1 to: 1 at: lastPos kern: kern.
	lastIndex _ saveIndex + 1.
	stopCondition ~= (stopConditions at: EndOfRun)
		ifTrue:	[^self perform: stopCondition]
		ifFalse: [lastIndex = runStopIndex
					ifTrue:	[^self perform: (stopConditions at: EndOfRun)].
				^false]
