string: aString fontName: fontName 
	"Answer an instance of me whose characters are those of.
	Use the font in the default TextStyle named by fontName."

	^ self string: aString emphasis:
		(TextStyle default fontNames indexOf: fontName ifAbsent: [1])