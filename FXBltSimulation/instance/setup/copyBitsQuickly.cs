copyBitsQuickly
	"Shortcut for stuff that's being run from the balloon engine.
	Since we do this at each scan line we should avoid the expensive 
	setup for source and destination."
	self inline: true.
	"We need rule 34, source depth 32, and no warping please."
	(combinationRule = 34 and:[sourceDepth = 32 and:[noWarp]]) ifFalse:[^false].
	"We need a source different from destination with at least 16bit depth."
	(noSource or:[sourceForm = destForm or:[destDepth <= 8]]) ifTrue:[^false].
	"If 8bit, then we want a dest map"
	(destDepth = 8 and:[noDestMap]) ifTrue:[^false].
	"And *no* source map please"
	noSourceMap ifFalse:[^false].
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