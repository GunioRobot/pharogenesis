installStrikeFont: aStrikeFont foregroundColor: foregroundColor backgroundColor: backgroundColor
	| lastSourceDepth |
	sourceForm ifNotNil:[lastSourceDepth _ sourceForm depth].
	sourceForm _ aStrikeFont glyphs.
	(colorMap notNil and:[lastSourceDepth = sourceForm depth]) ifFalse:
		["Set up color map for a different source depth (color font)"
		"Uses caching for reasonable efficiency"
		colorMap _ self cachedFontColormapFrom: sourceForm depth to: destForm depth.
		colorMap at: 1 put: (destForm pixelValueFor: backgroundColor)].
	sourceForm depth = 1 ifTrue:
		[colorMap at: 2 put: (destForm pixelValueFor: foregroundColor).
		"Ignore any halftone pattern since we use a color map approach here"
		halftoneForm _ nil].
	sourceY _ 0.
	height _ aStrikeFont height.
