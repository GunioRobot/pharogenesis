restoreDefaultFonts
	"Preferences restoreDefaultFonts"
	#(	(setButtonFontTo:		ComicBold		16)
		"(setCodeFontTo:			NewYork		12)"  "Later"
		(setFlapsFontTo:			ComicBold		16)
		(setListFontTo:			NewYork		12)
		(setMenuFontTo:			NewYork		12)
		(setWindowTitleFontTo:	NewYork		15)
		(setSystemFontTo:		NewYork		12)) do:
			[:triplet |
				self perform: triplet first with: (StrikeFont familyName: triplet second size: triplet third)].

	Smalltalk at: #BalloonMorph ifPresent:
		[:thatClass | thatClass setBalloonFontTo: (StrikeFont familyName: #ComicPlain size: 12)].

	"Note:  The standardCodeFont is not currently used -- the default font is instead; later hopefully we can split the code font out as  a separate choice, but only after we're able to have the protocols reorganized such that we can know whether it's code or not when we launch the text object.

	Note:  The standard button font is reset by this code but is not otherwise settable by a public UI (too many things can go afoul) "