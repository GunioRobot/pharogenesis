baseKern
	"Return the base kern value to be used for all characters."
	(emphasis noMask: 2) ifTrue: [^ 0].
	^ ((self height-1-self ascent+4)//4 max: 0)  "See makeItalicGlyphs"
		+ (((self ascent-5+4)//4 max: 0))
