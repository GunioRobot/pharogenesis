copyBits
	self clipRange.
	(bbW <= 0 or: [bbH <= 0]) ifTrue:
		["zero width or height; noop"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		^ nil].
 
	self destMaskAndPointerInit.
	bitCount _ 0.
	noSource
		ifTrue: [self copyLoopNoSource]
		ifFalse: [self checkSourceOverlap.
				(sourcePixSize ~= destPixSize
					or: [colorMap ~= interpreterProxy nilObject])
					ifTrue: [self copyLoopPixMap]
					ifFalse: [self sourceSkewAndPointerInit.
							self copyLoop]].
 
	combinationRule = 22 ifTrue:
		["zero width and height; return the count"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		interpreterProxy pop: 1.
		^ interpreterProxy pushInteger: bitCount].
 
	hDir > 0
		ifTrue: [affectedL _ dx.
				affectedR _ dx + bbW]
		ifFalse: [affectedL _ dx - bbW + 1.
				affectedR _ dx + 1].
	vDir > 0
		ifTrue: [affectedT _ dy.
				affectedB _ dy + bbH]
		ifFalse: [affectedT _ dy - bbH + 1.
				affectedB _ dy + 1]