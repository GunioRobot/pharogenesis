tryCopyingBitsQuickly
	"Shortcut for stuff that's being run from the balloon engine.
	Since we do this at each scan line we should avoid the expensive 
	setup for source and destination."
	self inline: true.
	"We need a source."
	noSource ifTrue:[^false].
	"We handle only combinationRule 34"
	(combinationRule = 34) ifFalse:[^false].
	"We handle only sourceDepth 32"
	(sourceDepth = 32) ifFalse:[^false].
	"We don't handle overlaps"
	(sourceForm = destForm) ifTrue:[^false].
	"We need at least 8bit deep dest forms"
	(destDepth < 8) ifTrue:[^false].
	"If 8bit, then we want a color map"
	(destDepth = 8 and:[(cmFlags bitAnd: ColorMapPresent) = 0]) ifTrue:[^false].
	destDepth = 32 
		ifTrue:[self alphaSourceBlendBits32].
	destDepth = 16
		ifTrue:[self alphaSourceBlendBits16].
	destDepth = 8
		ifTrue:[self alphaSourceBlendBits8].
	affectedL _ dx.
	affectedR _ dx + bbW.
	affectedT _ dy.
	affectedB _ dy + bbH.
	^true