pickSourcePixels: nPixels flags: mapperFlags srcMask: srcMask destMask: dstMask srcShiftInc: srcShiftInc dstShiftInc: dstShiftInc
	"Pick nPix pixels starting at srcBitIndex from the source, map by the
	color map, and justify them according to dstBitIndex in the resulting destWord."
	| sourceWord destWord sourcePix destPix srcShift dstShift nPix |
	self inline: true. "oh please"
	sourceWord _ self srcLongAt: sourceIndex.
	destWord _ 0.
	srcShift _ srcBitShift. "Hint: Keep in register"
	dstShift _ dstBitShift. "Hint: Keep in register"
	nPix _ nPixels. "always > 0 so we can use do { } while(--nPix);"
	(mapperFlags = (ColorMapPresent bitOr: ColorMapIndexedPart)) ifTrue:[
		"a little optimization for (pretty crucial) blits using indexed lookups only"
		[	"grab, colormap and mix in pixel"
			sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
			destPix _ self tableLookup: cmLookupTable at: (sourcePix bitAnd: cmMask).
			destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstShift.
			"adjust dest pix index"
			dstShift _ dstShift + dstShiftInc.
			"adjust source pix index"
			((srcShift _ srcShift + srcShiftInc) bitAnd: 16rFFFFFFE0) = 0 ifFalse:[
				sourceMSB ifTrue:[srcShift _ srcShift + 32] ifFalse:[srcShift _ srcShift - 32].
				sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
		(nPix _ nPix - 1) = 0] whileFalse.
	] ifFalse:[
		[	"grab, colormap and mix in pixel"
			sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
			destPix _ self mapPixel: sourcePix flags: mapperFlags.
			destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstShift.
			"adjust dest pix index"
			dstShift _ dstShift + dstShiftInc.
			"adjust source pix index"
			((srcShift _ srcShift + srcShiftInc) bitAnd: 16rFFFFFFE0) = 0 ifFalse:[
				sourceMSB ifTrue:[srcShift _ srcShift + 32] ifFalse:[srcShift _ srcShift - 32].
				sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
		(nPix _ nPix - 1) = 0] whileFalse.
	].
	srcBitShift _ srcShift. "Store back"
	^destWord
