srcPaint: sourceWord with: destinationWord
	"Replace those pixels in destinationWord where the
	associated pixel in sourceWord is different from sourceAlphaKey.
	Note: This will only work for sourceDepth = destDepth."
	| mask key result val |
	self inline: false.
	"Note: If sourceDepth ~= destDepth or warpMode the pixels are pre-merged"
	(sourceDepth = destDepth and:[noWarp])
		ifFalse:[^sourceWord].
	mask _ maskTable at: pixelDepth.
	key _ sourceAlphaKey.
	result _ 0.
	0 to: destPPW-1 do:[:i|
		(val _ sourceWord bitAnd: mask) = key
			ifTrue:[result _ result bitOr: (destinationWord bitAnd: mask)]
			ifFalse:[result _ result bitOr: val].
		mask _ mask << pixelDepth.
		key _ key << pixelDepth].
	^result