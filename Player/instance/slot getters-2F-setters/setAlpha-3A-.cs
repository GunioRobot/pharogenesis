setAlpha: alpha
	"Set the alpha of the color of my costume."

	| adjusted |
	adjusted _ (alpha max: 0.0) min: 1.0.
	^ self setColor: (self getColor alpha: adjusted)