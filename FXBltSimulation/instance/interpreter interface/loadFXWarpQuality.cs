loadFXWarpQuality
	"Load the warp quality (used, e.g., for warping)"
	self inline: true.
	warpQuality _ self fetchIntOrFloat: FXWarpQualityIndex ofObject: bitBltOop ifNil: 1.
	^interpreterProxy failed not