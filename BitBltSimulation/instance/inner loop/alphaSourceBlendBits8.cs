alphaSourceBlendBits8
	"This version assumes 
		combinationRule = 34
		sourcePixSize = 32
		destPixSize = 8
		sourceForm ~= destForm.
	Note: This is not real blending since we don't have the source colors available.
	"
	| srcIndex dstIndex sourceWord srcAlpha destWord deltaX deltaY 
	srcY dstY dstMask srcShift adjust mappingTable mapperFlags |
	self inline: false. "This particular method should be optimized in itself"
	self var: #mappingTable declareC:'unsigned int *mappingTable'.
	mappingTable _ self default8To32Table.
	mapperFlags _ cmFlags bitAnd: ColorMapNewStyle bitInvert32.
	deltaY _ bbH + 1. "So we can pre-decrement"
	srcY _ sy.
	dstY _ dy.
	mask1 _ ((dx bitAnd: 3) * 8).
	destMSB ifTrue:[mask1 _ 24 - mask1].
	mask2 _ AllOnes bitXor:(16rFF << mask1).
	(dx bitAnd: 1) = 0 
		ifTrue:[adjust _ 0]
		ifFalse:[adjust _ 16r1F1F1F1F].
	(dy bitAnd: 1) = 0
		ifTrue:[adjust _ adjust bitXor: 16r1F1F1F1F].
	"This is the outer loop"
	[(deltaY _ deltaY - 1) ~= 0] whileTrue:[
		adjust _ adjust bitXor: 16r1F1F1F1F.
		srcIndex _ sourceBits + (srcY * sourcePitch) + (sx * 4).
		dstIndex _ destBits + (dstY * destPitch) + (dx // 4 * 4).
		deltaX _ bbW + 1. "So we can pre-decrement"
		srcShift _ mask1.
		dstMask _ mask2.

		"This is the inner loop"
		[(deltaX _ deltaX - 1) ~= 0] whileTrue:[
			sourceWord _ ((self srcLongAt: srcIndex) bitAnd: (adjust bitInvert32)) + adjust.
			srcAlpha _ sourceWord >> 24.
			srcAlpha > 31 ifTrue:["Everything below 31 is transparent"
				srcAlpha < 224 ifTrue:["Everything above 224 is opaque"
					destWord _ self dstLongAt: dstIndex.
					destWord _ destWord bitAnd: dstMask bitInvert32.
					destWord _ destWord >> srcShift.
					destWord _ mappingTable at: destWord.
					sourceWord _ self alphaBlendScaled: sourceWord with: destWord.
				].
				sourceWord _ self mapPixel: sourceWord flags: mapperFlags.
				sourceWord _ sourceWord << srcShift.
				"Store back"
				self dstLongAt: dstIndex put: sourceWord mask: dstMask.
			].
			srcIndex _ srcIndex + 4.
			destMSB ifTrue:[
				srcShift = 0 
					ifTrue:[dstIndex _ dstIndex + 4.
							srcShift _ 24.
							dstMask _ 16r00FFFFFF]
					ifFalse:[srcShift _ srcShift - 8.
							dstMask _ (dstMask >> 8) bitOr: 16rFF000000].
			] ifFalse:[
				srcShift = 32
					ifTrue:[dstIndex _ dstIndex + 4.
							srcShift _ 0.
							dstMask _ 16rFFFFFF00]
					ifFalse:[srcShift _ srcShift + 8.
							dstMask _ dstMask << 8 bitOr: 255].
			].
			adjust _ adjust bitXor: 16r1F1F1F1F.
		].
		srcY _ srcY + 1.
		dstY _ dstY + 1.
	].