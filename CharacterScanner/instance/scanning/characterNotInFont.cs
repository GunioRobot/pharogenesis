characterNotInFont
	"Note: All fonts should have some sort of a character to glyph mapping.
	If a character is not in the font it should be mapped to the appropriate
	glyph (that is the glyph describing a non-existing character). If done
	correctly, this method should never be called. It is mainly provided
	for backward compatibility (and I'd really like to get rid of it - ar).

	All fonts have an illegal character to be used when a character is not 
	within the font's legal range. When characters out of ranged are 
	encountered in scanning text, then this special character indicates the 
	appropriate behavior. The character is usually treated as a unary 
	message understood by a subclass of CharacterScanner."

	| illegalAsciiString saveIndex stopCondition | 
	saveIndex _ lastIndex.
	illegalAsciiString _ String with: (font maxAscii + 1) asCharacter.
	stopCondition _ self scanCharactersFrom: 1 to: 1
			in: illegalAsciiString
			rightX: rightMargin stopConditions: stopConditions
			kern: kern.
	lastIndex _ saveIndex + 1.
	stopCondition ~= (stopConditions at: EndOfRun)
		ifTrue:	[^self perform: stopCondition]
		ifFalse: [lastIndex = runStopIndex
					ifTrue:	[^self perform: (stopConditions at: EndOfRun)].
				^false]
