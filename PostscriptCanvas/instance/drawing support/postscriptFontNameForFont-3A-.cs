postscriptFontNameForFont:font
	| fontName |
	fontName _ font familyName asString.
	font emphasis == 1 ifTrue:[
		fontName _ fontName,'-Bold'.
	].
	^self mapFontName:fontName.

