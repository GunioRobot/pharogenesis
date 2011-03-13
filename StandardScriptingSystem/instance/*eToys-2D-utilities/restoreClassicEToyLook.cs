restoreClassicEToyLook
	"Restore classic EToy look, as closely as possible.  If ComicBold is present, restore it as the standard etoy and button font.  Substitute ComicSansMS and Accuny as respective alternatives if the classic fonts are absent.  If those also aren't available, do nothing."

	| aTextStyle aFont | 
	(aTextStyle := TextStyle named: #ComicBold)
		ifNotNil:
			[aFont := aTextStyle fontOfSize: 16.
			Preferences setEToysFontTo: aFont.
			Preferences setButtonFontTo: aFont]
		ifNil:
			[(aTextStyle := TextStyle named: #ComicSansMS) ifNotNil:
				[Preferences setEToysFontTo: (aTextStyle fontOfSize: 18)].
			(aTextStyle := TextStyle named: #Accuny) ifNotNil:
				[Preferences setButtonFontTo: (aTextStyle fontOfSize: 12)]].

	(aTextStyle := TextStyle named: #NewYork)
		ifNotNil:
			[Preferences setSystemFontTo: (aTextStyle fontOfSize: 12)]