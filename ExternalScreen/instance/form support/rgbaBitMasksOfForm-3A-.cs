rgbaBitMasksOfForm: anExternalForm
	| rgbaBitMasks |
	rgbaBitMasks _ Array new: 4.
	self primForm: anExternalForm getExternalHandle colorMasksInto: rgbaBitMasks.
	^rgbaBitMasks