rgbaBitMasksOfTexture: anExternalTexture
	| rgbaBitMasks |
	rgbaBitMasks _ Array new: 4.
	self primTexture: anExternalTexture getExternalHandle colorMasksInto: rgbaBitMasks.
	^rgbaBitMasks