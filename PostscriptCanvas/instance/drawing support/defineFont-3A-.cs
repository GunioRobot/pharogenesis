defineFont:aFont
	(usedFonts includes: aFont) ifFalse:[
		usedFonts add:aFont.
		" here: define as Type-3 unless we think its available "
		" or, just remap"
		target remapFontForSqueak:(self postscriptFontNameForFont:aFont).
	].