paintingBoundsAround: dropPoint
	| anExtent possibleBounds |
	^ (self bounds area > ScriptingSystem maxPaintArea)
		ifTrue:
			[anExtent _ ScriptingSystem reasonablePaintingExtent.
			possibleBounds _ (dropPoint - (anExtent // 2)) extent: anExtent.
			possibleBounds intersect: self bounds]
		ifFalse:
			[self bounds]
