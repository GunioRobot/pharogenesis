initialize
	"self initialize"

	self fixFonts.
	self inform: 'Fonts were _fixed_.\The arrow glyph is now Character value ' withCRs,
		self arrowChar asInteger hex, ' ($', self arrowChar asString, ')'.
