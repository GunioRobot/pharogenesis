bitPatternForDepth: depth
	"Return a Bitmap, possibly containing a stipple pattern, that best represents this color at the given depth. BitBlt calls this method to convert colors into Bitmaps. The resulting Bitmap may be multiple words to represent a stipple pattern of several lines.  "
	"See also:	pixelValueAtDepth:	-- value for single pixel
				pixelWordAtDepth:	-- a 32-bit word filled with the pixel value"
	"Details: The pattern for the most recently requested depth is cached."

	depth == cachedDepth ifTrue: [^ cachedBitPattern].
	cachedDepth _ depth.

	depth > 2 ifTrue: [^ cachedBitPattern _ Bitmap with: (self pixelWordForDepth: depth)].
	depth = 1 ifTrue: [^ cachedBitPattern _ self halfTonePattern1].
	depth = 2 ifTrue: [^ cachedBitPattern _ self halfTonePattern2].
