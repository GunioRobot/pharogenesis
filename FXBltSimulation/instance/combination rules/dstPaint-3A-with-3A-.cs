dstPaint: sourceWord with: destinationWord
	"Replace those pixels in destinationWord where the
	pixel value is equal to destAlphaKey."
	| mask key result val |
	self inline: false.
	mask _ maskTable at: pixelDepth.
	key _ destAlphaKey.
	result _ 0.
	0 to: destPPW-1 do:[:i|
		(val _ destinationWord bitAnd: mask) = key
			ifTrue:[result _ result bitOr: (sourceWord bitAnd: mask)]
			ifFalse:[result _ result bitOr: val].
		mask _ mask << pixelDepth.
		key _ key << pixelDepth].
	^result