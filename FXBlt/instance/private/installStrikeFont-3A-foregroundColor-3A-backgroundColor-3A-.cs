installStrikeFont: aStrikeFont foregroundColor: foregroundColor backgroundColor: backgroundColor
	| lastSourceDepth |
	self flag: #fixThis.
	sourceForm ifNotNil:[lastSourceDepth _ sourceForm depth].
	sourceForm _ aStrikeFont glyphs.
	(colorMap notNil and:[lastSourceDepth = sourceForm depth]) ifFalse:
		["Set up color map for a different source depth (color font)"
		"Note this may need some caching for reasonable efficiency"
		colorMap _ (Color cachedColormapFrom: sourceForm depth to: destForm depth) copy.
		colorMap at: 1 put: (backgroundColor pixelValueForDepth: destForm depth).
		self colorMap: colorMap].
	sourceForm depth = 1 ifTrue:
		[colorMap colors at: 2 put: (foregroundColor pixelValueForDepth: destForm depth).
		"Ignore any halftone pattern since we use a color map approach here"
		halftoneForm _ nil].
	sourceY _ 0.
	height _ aStrikeFont height.
