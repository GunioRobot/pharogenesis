readPalette

	| r g b array |
	self next = 12 ifFalse: [self error: 'no Color Palette!'].
	array _ Array new: (1 bitShift: bitsPerPixel).
	1 to: array size do:
		[:i |
		r _ self next.  g _ self next.  b _ self next.
		array at: i put: (Color r: r g: g b: b range: 255)].
	^ array.
