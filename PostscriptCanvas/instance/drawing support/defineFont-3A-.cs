defineFont: aFont

	| psNameFor alreadyRemapped |

	(usedFonts includes: aFont) ifFalse:[
		psNameFor _ self postscriptFontNameForFont: aFont.
		alreadyRemapped _ usedFonts anySatisfy: [ :each | 
			(self postscriptFontNameForFont: each) = psNameFor
		].
		usedFonts add:aFont.
		" here: define as Type-3 unless we think its available "
		" or, just remap"

		" I had some problems if same font remapped twice"
		alreadyRemapped ifFalse: [target remapFontForSqueak: psNameFor].
	].