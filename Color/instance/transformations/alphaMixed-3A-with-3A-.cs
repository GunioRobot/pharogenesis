alphaMixed: proportion with: aColor
	"Same as #mixed:with: but including alpha"
	| frac1 frac2 |
	frac1 _ proportion asFloat min: 1.0 max: 0.0.
	frac2 _ 1.0 - frac1.
	^ (Color
		r: (self    red * frac1) + (aColor    red * frac2) 
		g: (self green * frac1) + (aColor green * frac2) 
		b: (self   blue * frac1) + (aColor  blue * frac2))
		alpha: (self alpha * frac1) + (aColor alpha * frac2)