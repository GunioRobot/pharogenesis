pickSourcePixels: nPixels srcMask: srcMask destMask: dstMask paintMode: paintMode destWord: destinationWord
	"Pick nPix pixels starting at srcBitIndex from the source, map by the
	color map, and justify them according to dstBitIndex in the resulting destWord."
	| sourceWord destWord sourcePix destPix srcShift dstShift nPix lastPix |
	"Note: The method must be inlined for LSB-MSB conversion"
	self inline: true.
	sourceWord _ self srcLongAt: sourceIndex.
	destWord _ 0.
	srcShift _ srcBitShift. "Hint: Keep in register"
	dstShift _ dstBitShift. "Hint: Keep in register"
	nPix _ nPixels. "always > 0 so we can use do { } while(--nPix);"
	"Pick and map first pixel so we can avoid the color conversion"
	lastPix _ sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
	destPix _ self mapPixel: sourcePix.
	["Mix in pixel"
	(paintMode and:[sourcePix = sourceAlphaKey]) ifTrue:[
		destWord _ destWord bitOr: (destinationWord bitAnd: (dstMask << dstShift)).
	] ifFalse:[destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstShift].
	destMSB
		ifTrue:[dstShift _ dstShift - destDepth]
		ifFalse:[dstShift _ dstShift + destDepth].
	"Adjust source if at pixel boundary"
	sourceMSB ifTrue:[
		(srcShift _ srcShift - sourceDepth) < 0 ifTrue:
			[srcShift _ srcShift + 32.
			sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
	] ifFalse:[
		(srcShift _ srcShift + sourceDepth) > 31 ifTrue:
			[srcShift _ srcShift - 32.
			sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
	].
	(nPix _ nPix - 1) = 0] whileFalse:["Pick and map next pixel"
		sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
		lastPix = sourcePix ifFalse:[
			"map the pixel(either into colorMap or destFormat)"
			destPix _ self mapPixel: sourcePix.
			lastPix _ sourcePix]].
	srcBitShift _ srcShift. "Store back"
	"*** side effect ***"
	"*** only the first pixel fetch can be unaligned ***"
	"*** prepare the next one for aligned access ***"
	destMSB
		ifTrue:[dstBitShift _ 32 - destDepth] "Shift towards leftmost pixel"
		ifFalse:[dstBitShift _ 0].
	^destWord