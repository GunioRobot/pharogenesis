installHaloTheme: themeSymbol
	self installHaloSpecsFromArray: (self perform: themeSymbol).
	self setParameter: #HaloTheme to: themeSymbol
	