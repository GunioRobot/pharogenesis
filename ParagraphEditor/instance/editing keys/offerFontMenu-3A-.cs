offerFontMenu: characterStream 
	"The user typed the command key that requests a font change; Offer the font menu.  5/27/96 sw
	 Keeps typeahead.  (?? should flush?)"

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self offerFontMenu.
	^ true