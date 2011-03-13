cachedFontColormapFrom: sourceDepth to: destDepth

	| srcIndex map |
	CachedFontColorMaps class == Array 
		ifFalse: [CachedFontColorMaps _ (1 to: 9) collect: [:i | Array new: 32]].
	srcIndex _ sourceDepth.
	sourceDepth > 8 ifTrue: [srcIndex _ 9].
	(map _ (CachedFontColorMaps at: srcIndex) at: destDepth) ~~ nil ifTrue: [^ map].

	map _ (Color cachedColormapFrom: sourceDepth to: destDepth) copy.
	(CachedFontColorMaps at: srcIndex) at: destDepth put: map.
	^ map
