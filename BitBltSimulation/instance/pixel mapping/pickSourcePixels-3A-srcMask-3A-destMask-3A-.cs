pickSourcePixels: nPix srcMask: sourcePixMask destMask: destPixMask
	"This version of pickSourcePixels is for sourcePixSize <= 8
		and colorMap notNil"
	"Pick nPix pixels from the source, mapped by the
	color map, and right-justify them in the resulting destWord."
	| sourceWord destWord sourcePix destPix |
	self inline: false.
	sourceWord _ (interpreterProxy longAt: sourceIndex).
	destWord _ 0.
	1 to: nPix do:
		[:i |
		sourcePix _ sourceWord >> ((32-sourcePixSize) - srcBitIndex)
					bitAnd: sourcePixMask.
		"look up sourcePix in colorMap"
		destPix _ (interpreterProxy fetchWord: sourcePix ofObject: colorMap) bitAnd: destPixMask.
		destWord _ (destWord << destPixSize) bitOr: destPix.
		(srcBitIndex _ srcBitIndex + sourcePixSize) > 31 ifTrue:
			[srcBitIndex _ srcBitIndex - 32.
			sourceIndex _ sourceIndex + 4.
			sourceWord _ interpreterProxy longAt: sourceIndex]].
	^ destWord