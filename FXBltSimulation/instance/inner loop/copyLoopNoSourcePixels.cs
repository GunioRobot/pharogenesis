copyLoopNoSourcePixels
	"This version of the inner loop maps dest pixels one at a time.
	Note: This loop is typically used for filling with alpha values.
	Note2: There is probably some significant speedup in here
	but for now I just need a version that does the job..."

	| nPix dstShift destWord dstIndex nLines dstMask lastDstPix destPix dstMapped resultMapped resultPix halftoneWord dstPaint mergeFn |
	self inline: false.
	mergeFn _ opTable at: combinationRule+1.
	dstPaint _ combinationRule = 36.

	"Additional inits"
	dstMask _ maskTable at: destDepth.
	dstIndex _ destIndex.

	"Precomputed shifts for pickSourcePixels"
	dstShift _ ((dx bitAnd: destPPW - 1) * destDepth).
	destMSB ifTrue:[dstShift _ 32 - destDepth - dstShift].
	dstBitShift _ dstShift.

	destMask _ -1.
	pixelDepth _ 32.
	nLines _ bbH.
	["this is the vertical loop"
		noHalftone
			ifTrue: [halftoneWord _ AllOnes]
			ifFalse: [halftoneWord _ self halftoneAt: bbH - nLines].
		destWord _ self dstLongAt: dstIndex.
		"Prefetch first dest pixel"
		lastDstPix _ destPix _ destWord >> dstShift bitAnd: dstMask.
		dstMapped _ self mapDestPixel: destPix.
		nPix _ bbW.
		["this is the horizontal loop"
			(dstPaint and:[destPix = destAlphaKey])
				ifTrue:[resultMapped _ dstMapped]
				ifFalse:[resultMapped _ self merge: halftoneWord with: dstMapped function: mergeFn].
			(noColorMap and:[resultMapped = dstMapped]) ifFalse:[
				resultPix _ self mapPixel: resultMapped.
				destWord _ destWord bitAnd: (dstMask << dstShift) bitInvert32.
				destWord _ destWord bitOr: (resultPix bitAnd: dstMask) << dstShift.
			].
			destMSB ifTrue:[
				"Adjust dest if at pixel boundary"
				(dstShift _ dstShift - destDepth) < 0 ifTrue:
					[dstShift _ dstShift + 32.
					self dstLongAt: dstIndex put: destWord.
					destWord _ self dstLongAt: (dstIndex _ dstIndex + 4)].
			] ifFalse:[
				"Adjust dest if at pixel boundary"
				(dstShift _ dstShift + destDepth) > 31 ifTrue:
					[dstShift _ dstShift - 32.
					self dstLongAt: dstIndex put: destWord.
					destWord _ self dstLongAt: (dstIndex _ dstIndex + 4)].
			].
		(nPix _ nPix - 1) = 0] whileFalse:[
			"Fetch next dest pixel"
			destPix _ destWord >> dstShift bitAnd: dstMask.
			lastDstPix = destPix ifFalse:[
				dstMapped _ self mapDestPixel: destPix.
				lastDstPix _ destPix]
		].
	(nLines _ nLines - 1) = 0] whileFalse:[
		"Store last modified word"
		self dstLongAt: dstIndex put: destWord.
		"Advance destIndex"
		dstIndex _ destIndex _ destIndex + destPitch.
		dstShift _ dstBitShift.
	].
	"Store final destWord"
	self dstLongAt: dstIndex put: destWord.