updateCacheCanvasDepth: depth
	"Update the cached image of the morphs being held by this hand."

	| myBnds rectList c |
	myBnds _ super fullBounds.  "my full bounds without my shadow"
	(cacheCanvas == nil or: [cacheCanvas extent ~= myBnds extent]) ifTrue: [
		cacheCanvas _ FormCanvas extent: myBnds extent depth: depth.
		c _ cacheCanvas copyOffset: myBnds origin negated.
		submorphs reverseDo: [:m | m fullDrawOn: c].
		cachedCanvasHasHoles _ (cacheCanvas form tallyPixelValues at: 1) > 0.
		^ self].

	"incrementally update the cache canvas"
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: myBnds extent).
	damageRecorder reset.
	rectList do: [:r |
		c _ cacheCanvas copyOrigin: myBnds origin negated clipRect: r.
		c fillColor: Color transparent.  "clear to transparent"
		submorphs reverseDo: [:m | m fullDrawOn: c].
	].
