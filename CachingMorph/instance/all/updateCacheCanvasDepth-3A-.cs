updateCacheCanvasDepth: depth
	"Update the cached image of the morphs being held by this hand."

	| myBnds rectList c |
	myBnds _ self fullBounds.
	(cacheCanvas == nil or: [cacheCanvas extent ~= myBnds extent]) ifTrue: [
		cacheCanvas _ FormCanvas extent: myBnds extent depth: depth.
		c _ cacheCanvas copyOffset: myBnds origin negated.
		^ super fullDrawOn: c].

	"incrementally update the cache canvas"
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: myBnds extent).
	damageRecorder reset.
	rectList do: [:r |
		c _ cacheCanvas copyOrigin: myBnds origin negated clipRect: r.
		c fillColor: Color transparent.  "clear to transparent"
		super fullDrawOn: c].
