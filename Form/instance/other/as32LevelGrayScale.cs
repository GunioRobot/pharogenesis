as32LevelGrayScale
	"Assume the receiver is a grayscale image. Return an grayscale 8-bit Form computed by extracting the brightness levels of one color component. This technique allows a 32-bit Form to be converted to an 8-bit Form to save space, while retaining all 32 levels of gray available in the 8-bit color map. (The default colormap quantizes grays to only 16 levels.)"

	| result |
	result _ Form extent: width@height depth: 8.
	self asGrayScale displayOn: result.
	^ result
