makeCondensedGlyphs
	"Make a condensed set of glyphs with same widths.
	NOTE: this has been superceded by kerning -- should not get called"
	| g newXTable x x1 w |
	g _ glyphs deepCopy.
	newXTable _ Array new: xTable size.
	newXTable at: 1 put: (x _ xTable at: 1).
	1 to: xTable size-1 do:
		[:i | x1 _ xTable at: i.  w _ (xTable at: i+1) - x1.
		w > 1 ifTrue: [w _ w-1].  "Shrink every character wider than 1"
		g copy: (x@0 extent: w@g height) from: x1@0 in: glyphs rule: Form over.
		newXTable at: i+1 put: (x _ x + w)].
	xTable _ newXTable.
	glyphs _ g
"
(TextStyle default fontAt: 1) copy makeCondensedGlyphs
	displayLine: 'The quick brown fox jumps over the lazy dog'
	at: Sensor cursorPoint
"