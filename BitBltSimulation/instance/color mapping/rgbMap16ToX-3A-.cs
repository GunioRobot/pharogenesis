rgbMap16ToX: sourcePixel
	"Convert the given 16 pixel value to a color value in destination format.
	Note: This method is intended to deal with different destination formats."
	destPixSize = 32
		ifTrue:[^self rgbMap16To32: sourcePixel]
		ifFalse:[^sourcePixel]
	"The above assumes that the caller is pickSourcePixels: using the standard
	16bit to 32bit conversion"