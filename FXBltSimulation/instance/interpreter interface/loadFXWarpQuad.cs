loadFXWarpQuad
	"Load the new warp quad (used, e.g., for warping)"
	| points oop |
	self inline: true.
	points _ interpreterProxy fetchPointer: FXWarpQuadIndex ofObject: bitBltOop.
	points = interpreterProxy nilObject ifTrue:[^noWarp _ true].
	noWarp _ false.
	(interpreterProxy fetchClassOf: points) = interpreterProxy classArray
		ifFalse:[^false].
	(interpreterProxy slotSizeOf: points) = 4 ifFalse:[^false].
	0 to: 3 do:[:i|
		oop _ interpreterProxy fetchPointer: i ofObject: points.
		(interpreterProxy fetchClassOf: oop) = interpreterProxy classPoint
			ifFalse:[^false].
		warpQuad at: i*2 put: (self fetchIntOrFloat: 0 ofObject: oop).
		warpQuad at: i*2+1 put: (self fetchIntOrFloat: 1 ofObject: oop).
	].
	^interpreterProxy failed not