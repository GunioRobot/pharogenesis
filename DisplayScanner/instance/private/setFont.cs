setFont 
	| map |
	foregroundColor _ paragraphColor.
	super setFont.  "Sets font and emphasis bits, and maybe foregroundColor"
	lastSourceDepth = sourceForm depth ifFalse:
		["Set up color map for a different source depth (color font)"
		"Note this may need some caching for reasonable efficiency"
		map _ (Color cachedColormapFrom: sourceForm depth to: destForm depth) copy.
		map at: 1 put: ((backgroundColor bitPatternForDepth: destForm depth) at: 1).
		self colorMap: map.
		lastSourceDepth _ sourceForm depth].
	sourceForm depth = 1 ifTrue:
		[(colorMap == nil or: [destForm depth = 1]) ifFalse:
			[colorMap at: 2 put: ((foregroundColor bitPatternForDepth: destForm depth) at: 1)]].
	destY _ lineY + line baseline - font ascent