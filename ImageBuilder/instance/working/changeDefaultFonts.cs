changeDefaultFonts
	" 
	FullImageTools new changeDefaultFonts.  
	"
	#(#(#setButtonFontTo: #BitstreamVeraSansMono 16) #(#setListFontTo: #BitstreamVeraSans 16) #(#setMenuFontTo: #BitstreamVeraSans 16) #(#setWindowTitleFontTo: #BitstreamVeraSans 21) #(#setSystemFontTo: #BitstreamVeraSans 16) #(#setFlapsFontTo: #ComicSansMS 24) #(#setCodeFontTo: #BitstreamVeraSerif 16)  #(#setEToysFontTo: #ComicSansMS 24) )
		do: [:triplet | Preferences
				perform: triplet first
				with: (StrikeFont familyName: triplet second size: triplet third)].
	""
	Smalltalk
		at: #BalloonMorph
		ifPresent: [:thatClass | thatClass
				setBalloonFontTo: (StrikeFont familyName: #BitstreamVeraSans size: 16)]