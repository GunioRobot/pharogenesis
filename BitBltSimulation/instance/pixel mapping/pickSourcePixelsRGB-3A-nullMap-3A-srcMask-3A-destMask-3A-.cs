pickSourcePixelsRGB: nPix nullMap: nullMap srcMask: sourcePixMask destMask: destPixMask
	"This version of pickSourcePixels is for sourcePixSize >= 16"
	"Pick nPix pixels from the source, mapped by the
	color map, and right-justify them in the resulting destWord.
	Incoming pixels of 16 or 32 bits are first reduced to cmBitsPerColor.
	With no color map, pixels are just masked or zero-filled or
	if 16- or 32-bit pixels, the r, g, and b are so treated individually."
	| sourceWord destWord sourcePix destPix |
	self inline: false.
	sourceWord _ (interpreterProxy longAt: sourceIndex).
	destWord _ 0.
	1 to: nPix do:
		[:i |
		sourcePix _ sourceWord >> ((32-sourcePixSize) - srcBitIndex)
					bitAnd: sourcePixMask.
		nullMap
		ifTrue:
			["Map between RGB pixels"
			sourcePixSize = 16
				ifTrue: [destPix _ self rgbMap: sourcePix from: 5 to: 8]
				ifFalse: [destPix _ self rgbMap: sourcePix from: 8 to: 5]]
		ifFalse:
			["RGB pixels first get reduced to cmBitsPerColor"
			sourcePixSize = 16
				ifTrue: [sourcePix _ self rgbMap: sourcePix from: 5 to: cmBitsPerColor]
				ifFalse: [sourcePix _ self rgbMap: sourcePix from: 8 to: cmBitsPerColor].
			"Then look up sourcePix in colorMap"
			destPix _ (interpreterProxy fetchWord: sourcePix ofObject: colorMap) bitAnd: destPixMask].
		destWord _ (destWord << destPixSize) bitOr: destPix.
		(srcBitIndex _ srcBitIndex + sourcePixSize) > 31 ifTrue:
			[srcBitIndex _ srcBitIndex - 32.
			sourceIndex _ sourceIndex + 4.
			sourceWord _ interpreterProxy longAt: sourceIndex]].
	^ destWord