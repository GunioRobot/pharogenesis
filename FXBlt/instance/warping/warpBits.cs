warpBits
	warpQuality ifNil:[warpQuality _ 1].
	warpQuality > 1 ifTrue:[
		"Must install source map"
		sourceMap _ sourceForm colormapToARGB.
		colorMap _ destForm colormapFromARGB.
	].
	self copyBits