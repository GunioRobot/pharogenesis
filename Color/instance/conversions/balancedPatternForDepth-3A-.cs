balancedPatternForDepth: depth
	"A generalization of bitPatternForDepth: as it exists.  Generates a 2x2 stipple of color.
	The topLeft and bottomRight pixel are closest approx to this color"
	| pv1 pv2 mask1 mask2 pv3 c |
	depth == cachedDepth ifTrue: [^ cachedBitPattern].
	(depth between: 4 and: 16) ifFalse: [^ self bitPatternForDepth: depth].
	cachedDepth _ depth.
	pv1 _ self pixelValueForDepth: depth.
"
	Subtract error due to pv1 to get pv2.
	pv2 _ (self - (err1 _ (Color colorFromPixelValue: pv1 depth: depth) - self))
						pixelValueForDepth: depth.
	Subtract error due to 2 pv1's and pv2 to get pv3.
	pv3 _ (self - err1 - err1 - ((Color colorFromPixelValue: pv2 depth: depth) - self))
						pixelValueForDepth: depth.
"
	"Above two statements computed faster by the following..."
	pv2 _ (c _ self - ((Color colorFromPixelValue: pv1 depth: depth) - self))
						pixelValueForDepth: depth.
	pv3 _ (c + (c - (Color colorFromPixelValue: pv2 depth: depth)))
						pixelValueForDepth: depth.

	"Return to a 2-word bitmap that encodes a 2x2 stipple of the given pixelValues."
	mask1 _ (#(- - -	
			16r01010101 - - -			"replicates every other 4 bits"
			16r00010001 - - - - - - -	"replicates every other 8 bits"
			16r00000001) at: depth).	"replicates every other 16 bits"
	mask2 _ (#(- - -	
			16r10101010 - - -			"replicates the other 4 bits"
			16r01000100 - - - - - - -	"replicates the other 8 bits"
			16r00010000) at: depth).	"replicates the other 16 bits"
	^ Bitmap with: (mask1*pv1) + (mask2*pv2) with: (mask1*pv3) + (mask2*pv1)