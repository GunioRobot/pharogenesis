createCharacterToGlyphMap
	"Private. Create the character to glyph mapping for a font that didn't have any before. This is basically equivalent to what the former setStopCondition did, only based on indexes."
	| map |
	map _ Array new: 256.
	0 to: minAscii - 1 do:[:i| map at: i + 1 put: maxAscii + 1].
	minAscii to: maxAscii do:[:i| map at: i + 1 put: i].
	maxAscii + 1 to: 255 do:[:i| map at: i + 1 put: maxAscii + 1].
	^map