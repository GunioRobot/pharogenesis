rgbaBitMasks
	"Return the masks for specifying the R,G,B, and A components in the receiver"
	| rgbaBitMasks |
	rgbaBitMasks _ Array new: 4.
	self primDisplay: bits colorMasksInto: rgbaBitMasks.
	^rgbaBitMasks