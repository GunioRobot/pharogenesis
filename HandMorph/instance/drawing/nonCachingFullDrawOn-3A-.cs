nonCachingFullDrawOn: aCanvas
	"A HandMorph has unusual drawing requirements:
		1. the hand itself (i.e., the cursor) appears in front of its submorphs
		2. morphs being held by the hand cast a shadow on the world/morphs below
	The illusion is that the hand plucks up morphs and carries them above the world."
	"Note: This version does not cache an image of the morphs being held by the hand.
	 Thus, it is slower for complex morphs, but consumes less space."

	| shadowCanvas |
	submorphs isEmpty ifTrue: [^ self drawOn: aCanvas].  "just draw the hand itself"

	shadowCanvas _ aCanvas copyForShadowDrawingOffset: self shadowOffset.
	submorphs reverseDo: [:m | m fullDrawOn: shadowCanvas].  "draw shadows"
	submorphs reverseDo: [:m | m fullDrawOn: aCanvas].  "draw morphs in front of shadows"
	self drawOn: aCanvas.  "draw the hand itself in front of morphs"
