pickSourcePixelsNullMap: nPix srcMask: sourcePixMask destMask: destPixMask
	"This version of pickSourcePixels is for colorMap==nil.
		SourcePixelSize is also known to be 8 bits or less."
	"With no color map, pixels are just masked or zero-filled."
	| sourceWord destWord sourcePix |
	self inline: false.
	sourceWord _ (interpreterProxy longAt: sourceIndex).
	destWord _ 0.
	1 to: nPix do:
		[:i |
		sourcePix _ sourceWord >> ((32-sourcePixSize) - srcBitIndex)
					bitAnd: sourcePixMask.
		destWord _ (destWord << destPixSize) 
					bitOr: (sourcePix bitAnd: destPixMask).
		(srcBitIndex _ srcBitIndex + sourcePixSize) > 31 ifTrue:
			[srcBitIndex _ srcBitIndex - 32.
			sourceIndex _ sourceIndex + 4.
			sourceWord _ interpreterProxy longAt: sourceIndex]].
	^ destWord