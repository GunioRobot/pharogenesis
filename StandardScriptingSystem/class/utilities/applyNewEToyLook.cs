applyNewEToyLook
	"Apply the new EToy look based on free fonts, approximating the classic look as closely as possible."

	"StandardScriptingSystem applyNewEToyLook"

"	| aTextStyle aFont | 
	aTextStyle _ TextStyle named: #BitstreamVeraSansMono.
	aFont _ aTextStyle fontOfSize: 12.
	aFont _ aFont emphasis: 1.
	Preferences setEToysFontTo: aFont.
	Preferences setButtonFontTo: aFont.

	aTextStyle _ TextStyle named: #Accushi.
	aFont _ aTextStyle fontOfSize: 12.
	Preferences setFlapsFontTo: aFont.

	(aTextStyle _ TextStyle named: #Accuny)
		ifNotNil:
			[Preferences setSystemFontTo: (aTextStyle fontOfSize: 12)]"

	Preferences setDefaultFonts: #(
		(setEToysFontTo:			BitstreamVeraSansBold	10)
		(setButtonFontTo:		BitstreamVeraSansMono	9)
		(setFlapsFontTo:			Accushi				12)
		(setSystemFontTo:		Accuny				10)
		(setWindowTitleFontTo:	BitstreamVeraSansBold	12)
	)
