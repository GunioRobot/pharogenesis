rgbMap32ToX: sourcePixel
	"Convert the given 32bit pixel value to a color value in destination format.
	Note: This method is intended to deal with different destination formats."
	destPixSize = 16
		ifTrue:[^self rgbMap32: sourcePixel to: 5]
		ifFalse:[^sourcePixel]
	"The above assumes that the caller is pickSourcePixels: using the standard
	32bit to 16bit conversion"