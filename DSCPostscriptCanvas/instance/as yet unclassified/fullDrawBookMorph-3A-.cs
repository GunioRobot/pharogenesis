fullDrawBookMorph:aBookMorph
	" draw all the pages in a book morph, but only if it is the top-level morph "

	morphLevel == 1 ifTrue:[
		self drawPages:aBookMorph pages.
	] ifFalse:[
		^super fullDrawBookMorph:aBookMorph.
	].
	target print:'%%EOF'; cr.
