copyBits
	"This function is exported for the Balloon engine"
	self export: true.
	self inline: false.
	self clipRange.
	(bbW <= 0 or: [bbH <= 0]) ifTrue:
		["zero width or height; noop"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		^ nil].
	"Lock the surfaces"
	self lockSurfaces ifFalse:[^interpreterProxy primitiveFail].
	self copyBitsLockedAndClipped.
	self unlockSurfaces.