fullDrawOn: aCanvas
	"A HandMorph has unusual drawing requirements:
		1. the hand itself (i.e., the cursor) appears in front of its submorphs
		2. morphs being held by the hand cast a shadow on the world/morphs below
	The illusion is that the hand plucks up morphs and carries them above the world."
	"Note: This version caches an image of the morphs being held by the hand for
	 better performance. This cache is invalidated if one of those morphs changes."

	| disableCaching myBnds shadowCanvas |
	disableCaching _ false.
	disableCaching ifTrue: [self nonCachingFullDrawOn: aCanvas. ^ self].

	submorphs isEmpty ifTrue: [
		cacheCanvas _ nil.
		^ self drawOn: aCanvas].  "just draw the hand itself"

	myBnds _ super fullBounds.  "my full bounds without my shadow"
	self updateCacheCanvasDepth: aCanvas depth.

	"draw the shadow"
	shadowCanvas _ aCanvas copyForShadowDrawingOffset: self shadowOffset.
	"Note: it's 3x faster to fill a rectangle rather than draw the shadow of a Form"
	cachedCanvasHasHoles
		ifTrue: [shadowCanvas image: cacheCanvas form at: myBnds origin]
		ifFalse: [shadowCanvas fillRectangle: myBnds color: color].

	"draw morphs in front of the shadow using the cached Form"
	aCanvas image: cacheCanvas form at: myBnds origin.
	self drawOn: aCanvas.  "draw the hand itself in front of morphs"
