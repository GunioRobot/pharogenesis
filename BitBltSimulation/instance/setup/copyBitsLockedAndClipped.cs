copyBitsLockedAndClipped
	"Perform the actual copyBits operation.
	Assume: Surfaces have been locked and clipping was performed."
	| done |
	self inline: true.
	"Try a shortcut for stuff that should be run as quickly as possible"
 	done _ self tryCopyingBitsQuickly.
	done ifTrue:[^nil].

	(combinationRule = 30) | (combinationRule = 31) ifTrue:
		["Check and fetch source alpha parameter for alpha blend"
		interpreterProxy methodArgumentCount = 1
			ifTrue: [sourceAlpha _ interpreterProxy stackIntegerValue: 0.
					(interpreterProxy failed not and: [(sourceAlpha >= 0) & (sourceAlpha <= 255)])
						ifFalse: [^ interpreterProxy primitiveFail]]
			ifFalse: [^ interpreterProxy primitiveFail]].

	bitCount _ 0.
	"Choose and perform the actual copy loop."
	self performCopyLoop.

	(combinationRule = 22) | (combinationRule = 32) ifTrue:
		["zero width and height; return the count"
		affectedL _ affectedR _ affectedT _ affectedB _ 0]. 
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