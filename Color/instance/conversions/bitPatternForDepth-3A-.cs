bitPatternForDepth: depth
	"The raw call on BitBlt needs a Bitmap to represent this color.  Return the color at the destination Form depth as a Bitmap.  Pattern returns a longer Bitmap.  6/14/96 tk
	For the bits that are in a single pixel, use pixelValueAtDepth:.
	For a 32-bit integer of (32/depth) pixels, use pixelWordAtDepth:"

	depth == cachedDepth ifTrue: [^ cachedBitPattern].
	cachedDepth _ depth.

	depth > 1 ifTrue: [^ cachedBitPattern _ Bitmap with: (self pixelWordForDepth: depth)].

	"Spatial halftone for gray for depth 1"
	self = Black ifTrue: [^ cachedBitPattern _ Bitmap with: 16rFFFFFFFF].
	self = White ifTrue: [^ cachedBitPattern _ Bitmap with: 16r0].
	self = Gray ifTrue: [^ cachedBitPattern _ Bitmap with: 16r55555555 with: 16rAAAAAAAA].
	self = LightGray ifTrue: [^ cachedBitPattern _ Bitmap with: 16r44444444 with: 16r11111111].
	self = DarkGray ifTrue: [^ cachedBitPattern _ Bitmap with: 16rBBBBBBBB with: 16rEEEEEEEE].
	^ cachedBitPattern _ Bitmap with: 16r0.	"everything else"