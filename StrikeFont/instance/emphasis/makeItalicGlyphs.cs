makeItalicGlyphs
	"Make an italic set of glyphs with same widths by skewing left and right
		(may require more intercharacter space)"
	| g r bonkForm bc |
	g _ glyphs deepCopy.
	"BonkForm will have bits where slanted characters overlap their neighbors."
	bonkForm _ Form extent: (self height//4+2) @ self height.
	bc _ self descent//4 + 1.  "Bonker x-coord corresponding to char boundary."
	bonkForm fill: (0 @ 0 corner: (bc+1) @ self ascent) fillColor: Color black.
	4 to: self ascent-1 by: 4 do:
		[:y | 		"Slide ascenders right..."
		g copy: (1@0 extent: g width @ (self ascent - y))
			from: 0@0 in: g rule: Form over.
		bonkForm copy: (1@0 extent: bonkForm width @ (self ascent - y))
			from: 0@0 in: bonkForm rule: Form over].
	bonkForm fill: (0 @ 0 corner: (bc+1) @ self ascent) fillColor: Color white.
	bonkForm fill: (bc @ self ascent corner: bonkForm extent) fillColor: Color black.
	self ascent to: self height-1 by: 4 do:
		[:y | 		"Slide descenders left..."
		g copy: (0@y extent: g width @ g height)
			from: 1@y in: g rule: Form over.
		bonkForm copy: (0@0 extent: bonkForm width @ bonkForm height)
			from: 1@0 in: bonkForm rule: Form over].
	bonkForm fill: (bc @ self ascent corner: bonkForm extent) fillColor: Color white.
	"Now use bonkForm to erase at every character boundary in glyphs."
	bonkForm offset: (0-bc) @ 0.
	self bonk: g with: bonkForm.
	glyphs _ g
