hasGlyphOf: aCharacter
	"Answer whether this font includes a glyph for the given character"
	^ aCharacter charCode <= self maxAscii
