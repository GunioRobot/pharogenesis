chooseBalloonFont
	"BalloonMorph chooseBalloonFont"

	Preferences chooseFontWithPrompt:  'Select the font to be
used for balloon help'
		andSendTo: self withSelector: #setBalloonFontTo: