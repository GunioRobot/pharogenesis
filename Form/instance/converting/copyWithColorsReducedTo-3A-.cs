copyWithColorsReducedTo: nColors
	"Note: this has not been engineered.
	There are better solutions in the literature."
	| palette colorMap pc closest |
	palette _ self reducedPaletteOfSize: nColors.
	colorMap _ (1 to: (1 bitShift: depth)) collect:
		[:i | pc _ Color colorFromPixelValue: i-1 depth: depth.
		closest _ palette detectMin: [:c | c diff: pc].
		closest pixelValueForDepth: depth].
	^ self deepCopy copyBits: self boundingBox from: self at: 0@0 colorMap: (colorMap as: Bitmap)
		