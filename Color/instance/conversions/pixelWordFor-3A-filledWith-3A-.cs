pixelWordFor: depth filledWith: pixelValue
	"Return to a 32-bit word that concatenates enough copies of the given pixel value to fill the word (i.e., 32/depth copies). Depth should be one of 1, 2, 4, 8, 16, or 32. The pixel value should be an integer in 0..2^depth-1."

	depth = 32 ifTrue: [^ pixelValue].
	^ (pixelValue bitAnd: (1 bitShift: depth) - 1) * 
		(#(16rFFFFFFFF				"replicates at every bit"
			16r55555555 -			"replicates every 2 bits"
			16r11111111 - - -			"replicates every 4 bits"
			16r01010101 - - - - - - -	"replicates every 8 bits"
			16r00010001) at: depth)	"replicates every 16 bits"
