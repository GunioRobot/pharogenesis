chooseFont: aFontOrNil title: label
	"Answer the user choice of a font."
	
	^UITheme current
		chooseFontIn: self modalMorph
		title: (label ifNil: ['Choose Font' translated])
		font: aFontOrNil