makeStruckOutGlyphs
	"Make a struck-out set of glyphs with same widths"
	| g |
	g _ glyphs deepCopy.
	g fillBlack: (0 @ (self ascent - (self ascent//3)) extent: g width @ 1).
	glyphs _ g
