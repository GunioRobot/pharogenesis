setMenuFontTo: aFont
	MenuStyle _ aFont textStyle copy consistOnlyOf: aFont.
	MenuStyle 
		gridForFont: 1 withLead: 0;
		centered.
	self allSubInstancesDo: [:m | m rescan].
	Utilities replaceMenuFlap