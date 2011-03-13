pixelWordForDepth: depth
	"Answer bits that appear in a 32-bit word of a Bitmap of the given depth. This may represent between 32 and 1 pixels, depending on the depth.  The depth must be one of 1, 2, 4, 8, 16, or 32.  Returns an integer."
	| word d |
	word _ self pixelValueForDepth: depth.
	d _ depth.
	[d >= 32] whileFalse: [
		word _ word bitOr: (word bitShift: d).
		d _ d+d].
	^ word