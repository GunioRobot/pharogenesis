defineFont: aFont

	| psNameFor alreadyRemapped |

	(usedFonts includesKey: aFont) ifFalse:[
		psNameFor _ self postscriptFontNameForFont: aFont.
		alreadyRemapped _ usedFonts includes: psNameFor.
		usedFonts at: aFont put: psNameFor.
		" here: define as Type-3 unless we think its available "
		" or, just remap"

		" I had some problems if same font remapped twice"
		alreadyRemapped ifFalse: [target remapFontForSqueak: psNameFor].
	].