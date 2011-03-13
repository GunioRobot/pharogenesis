mixed: proportion with: aColor
	"Answer this color mixed with the given color. The proportion,
	 a number between 0.0 and 1.0, determines what what fraction
	 of the receiver to use in the mix. For example, 0.9 would yield
	 a color close to the receiver."
	"Details: This method uses RGB interpolation; HSV interpolation
	 can lead to surprises."

	| frac1 frac2 |
	frac1 _ proportion asFloat min: 1.0 max: 0.0.
	frac2 _ 1.0 - frac1.
	^ Color
		red: (self    red * frac1) + (aColor    red * frac2) 
		green: (self green * frac1) + (aColor green * frac2) 
		blue: (self   blue * frac1) + (aColor  blue * frac2)
