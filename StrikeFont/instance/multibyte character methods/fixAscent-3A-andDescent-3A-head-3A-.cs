fixAscent: a andDescent: d head: h

	| bb newGlyphs |
	"(a + d) = (ascent + descent) ifTrue: ["
		ascent _ a.
		descent _ d.
		newGlyphs _ Form extent: (glyphs width@(h + glyphs height)).
		bb _ BitBlt toForm: newGlyphs.
		bb copy: (0@h extent: (glyphs extent)) from: 0@0 in: glyphs
			fillColor: nil rule: Form over.
		glyphs _ newGlyphs.
	"]."
