makeBoldGlyphs
	"Make a bold set of glyphs with same widths by ORing 1 bit to the right
		(requires at least 1 pixel of intercharacter space)"
	| g bonkForm |
	g _ glyphs deepCopy.
	bonkForm _ (Form extent: 1@16) fillBlack offset: -1@0.
	self bonk: g with: bonkForm.
	g copyBits: g boundingBox from: g at: (1@0)
		clippingBox: g boundingBox rule: Form under fillColor: nil.
	glyphs _ g