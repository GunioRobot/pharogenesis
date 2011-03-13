layoutBounds: aRectangle
	"Set the bounds for laying out children of the receiver.
	Note: written so that #layoutBounds can be changed without touching this method"
	| outer inner |
	outer _ self bounds.
	inner _ self layoutBounds.
	bounds _ aRectangle origin + (outer origin - inner origin) corner:
				aRectangle corner + (outer corner - inner corner).