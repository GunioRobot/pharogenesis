installDejaVu
	"Warning: Uses the methods in 'dejaVu font data' category, that will be removed soon (or are already removed) to save space."
"
StrikeFont installDejaVu
"

	TextConstants at: 'Bitmap DejaVu Sans' put: (TextStyle fontArray: 
		(Array
			with: (self createDejaVu: 7)
			with: (self createDejaVu: 9)
			with: (self createDejaVu: 12))).
	Preferences restoreDefaultFonts.
	StrikeFont limitTo16Bits.
	StrikeFont useUnderscoreIfOver1bpp