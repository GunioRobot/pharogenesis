copyBits
	self export: true.
	self inline: false.
	self initBBOpTable.
	self clipDest.
	"Clip against source if not warping"
	noSource ifFalse:[
		noWarp ifTrue:[self clipSource]].
	(bbW <= 0 or: [bbH <= 0]) ifTrue:
		["zero width or height; noop"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		^ nil].
	"Lock the surfaces if necessary"
	hasSurfaceLock _ false.
	(destBits = 0 or:[noSource not and:[sourceBits = 0]])
		ifTrue:[self lockSurfaces ifFalse:[^interpreterProxy primitiveFail]].
	self copyBitsLockedAndClipped.
	"And unlock the surfaces if necessary"
	hasSurfaceLock ifTrue:[self unlockSurfaces].