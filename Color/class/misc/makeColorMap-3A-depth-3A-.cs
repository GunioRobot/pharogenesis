makeColorMap: colorArray depth: bitsPerPixel
	"colorArray is now an Array of (256) Colors that the picture wants to use.  We have a fixed palette of 256 Colors.  Convert each to the closest of our colors and return a mapping vector.  Note we use zero-order (0-255) colors here.  6/24/96 tk"

	bitsPerPixel > 8 ifTrue: [self error: 'Unknown depth'].
		"GIFs can't come in 16, 24, or 32"
		"later deal with 3,4,5,6,7 bit deep GIFs"
	^ colorArray collect: [:color | 
		color pixelValueForDepth: bitsPerPixel].
