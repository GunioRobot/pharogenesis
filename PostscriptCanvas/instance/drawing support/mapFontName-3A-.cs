mapFontName:fontName
	^ fontMap at:fontName ifAbsent:[fontName].
