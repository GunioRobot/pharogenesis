makeUnderlinedGlyphs
	"Make an underlined set of glyphs with same widths"
	| g |
	g _ glyphs deepCopy.
	g fillBlack: (0 @ (self ascent+1) extent: g width @ 1).
	glyphs _ g
