imageForm

	self updateCacheCanvasDepth: Display depth.
	^ cacheCanvas form offset: self fullBounds topLeft
