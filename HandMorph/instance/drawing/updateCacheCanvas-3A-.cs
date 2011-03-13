updateCacheCanvas: aCanvas
	"Update the cached image of the morphs being held by this hand."
	| subBnds rectList |
	"Note: The following is an attempt to quickly get out if there's no change"
	subBnds _ Rectangle merging: (submorphs collect: [:m | m fullBounds]).
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: subBnds extent).
	(rectList isEmpty and:[cacheCanvas notNil and:[cacheCanvas extent = subBnds extent]])
		ifTrue:[^self].

	"Always check for real translucency -- can't be cached in a form"
	self allMorphsDo: [:m |
		m hasTranslucentColor ifTrue: [
			cacheCanvas _ nil.
			cachedCanvasHasHoles _ true.
			^ self]].

	(cacheCanvas == nil or: [cacheCanvas extent ~= subBnds extent]) ifTrue: [
		cacheCanvas _ (aCanvas allocateForm: subBnds extent) getCanvas.
		cacheCanvas translateBy: subBnds origin negated
			during:[:tempCanvas| self drawSubmorphsOn: tempCanvas].
		self submorphsDo:
			[:m | (m areasRemainingToFill: subBnds) isEmpty
				ifTrue: [^ cachedCanvasHasHoles _ false]].
		cachedCanvasHasHoles _ (cacheCanvas form tallyPixelValues at: 1) > 0.
		^ self].

	"incrementally update the cache canvas"
	rectList _ damageRecorder invalidRectsFullBounds: (0@0 extent: subBnds extent).
	damageRecorder reset.
	rectList do: [:r |
		cacheCanvas translateTo: subBnds origin negated clippingTo: r during:[:c|
			c fillColor: Color transparent.  "clear to transparent"
			self drawSubmorphsOn: c]].