read24BmpLine: pixelLine into: formBits startingAt: formBitsIndex width: width
	| pixIndex rgb bitsIndex |
	pixIndex _ 0. "pre-increment"
	bitsIndex := formBitsIndex-1. "pre-increment"
	1 to: width do: [:j |
		rgb := 
			(pixelLine at: (pixIndex := pixIndex+1)) +
			((pixelLine at: (pixIndex := pixIndex+1)) bitShift: 8) +
			((pixelLine at: (pixIndex := pixIndex+1)) bitShift: 16).
		formBits at: (bitsIndex := bitsIndex+1) put: rgb.
	].
