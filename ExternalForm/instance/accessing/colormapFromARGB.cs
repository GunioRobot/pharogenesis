colormapFromARGB
	"Return a ColorMap mapping from canonical ARGB pixel values into the receiver"
	^argbMap ifNil:[argbMap _ ColorMap mappingFromARGB: self rgbaBitMasks].