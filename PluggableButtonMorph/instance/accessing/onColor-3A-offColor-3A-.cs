onColor: colorWhenOn offColor: colorWhenOff
	"Set the fill colors to be used when this button is on/off."

	onColor _ colorWhenOn.
	offColor _ colorWhenOff.
	self update: nil.
