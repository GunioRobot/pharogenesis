emphasized: code
	| derivative addedEmphasis base safeCode |
	code = 0 ifTrue: [^ self].
	derivativeFonts == nil ifTrue:[derivativeFonts _ Array new: 32].
	derivative _ derivativeFonts at: (safeCode _ code min: derivativeFonts size).
	derivative == nil ifFalse: [^ derivative].  "Already have this style"

	"Dont have it -- derive from another with one with less emphasis"
	addedEmphasis _ 1 bitShift: safeCode highBit - 1.
	base _ self emphasized: safeCode - addedEmphasis.  "Order is Bold, Ital, Under, Narrow"
	addedEmphasis = 1 ifTrue:   "Compute synthetic bold version of the font"
		[derivative _ (base copy name: base name) makeBoldGlyphs].
	addedEmphasis = 2 ifTrue:   "Compute synthetic italic version of the font"
		[ derivative _ (base copy name: base name) makeItalicGlyphs].
	addedEmphasis = 4 ifTrue:   "Compute underlined version of the font"
		[derivative _ (base copy name: base name) makeUnderlinedGlyphs].
	addedEmphasis = 8 ifTrue:   "Compute narrow version of the font"
		[derivative _ (base copy name: base name) makeCondensedGlyphs].
	addedEmphasis = 16 ifTrue:   "Compute struck-out version of the font"
		[derivative _ (base copy name: base name) makeStruckOutGlyphs].
	derivative emphasis: safeCode.
	derivativeFonts at: safeCode put: derivative.
	^ derivative