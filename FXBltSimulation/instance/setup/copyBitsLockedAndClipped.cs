copyBitsLockedAndClipped
	"Perform the actual copyBits operation.
	Assume: Surfaces have been locked and clipping was performed."
	| done |
	self inline: true.
	pixelDepth _ destDepth. "default assumption"
	bitCount _ 0.
	"Try a shortcut for stuff that should be run as quickly as possible"
 	done _ self copyBitsQuickly.
	done ifTrue:[^nil].
	self destMaskAndPointerInit.
	noWarp ifTrue:[
		"Choose and perform the actual copy loop."
		noSource ifTrue: ["Simple fill loop"
			noDestMap
				ifTrue:[self copyLoopNoSource]
				ifFalse:[self copyLoopNoSourcePixels].
		] ifFalse: ["Loop using source and dest"
			self checkSourceOverlap.
			(sourceDepth = destDepth and:[
				sourceMSB = destMSB and:[noColorMap and:[srcKeyMode not]]]) ifTrue: [
				"Faster version when equal depths and no color conversion"
				self sourceSkewAndPointerInit.
				self copyLoop.
			] ifFalse: [
				"If we must convert between pixel depths or use
				color lookups use the general version"
				(noSourceMap and:[noDestMap])
					ifTrue:[self doCopyLoopPixMap]
					ifFalse:[self copyLoopPixels].
			]
		].
	] ifFalse:[self doWarpLoop].
	(combinationRule = 22) | (combinationRule = 32) ifTrue:
		["zero width and height; return the count"
		affectedL _ affectedR _ affectedT _ affectedB _ 0.
		interpreterProxy pop: interpreterProxy methodArgumentCount + 1.
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