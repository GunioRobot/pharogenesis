alphaSourceBlendBits16
	"This version assumes 
		combinationRule = 34
		sourcePixSize = 32
		destPixSize = 16
		sourceForm ~= destForm.
	"
	| srcIndex dstIndex sourceWord srcAlpha destWord deltaX deltaY 
	srcY dstY dstMask srcShift ditherBase ditherIndex ditherThreshold |
	self inline: false. "This particular method should be optimized in itself"
	deltaY _ bbH + 1. "So we can pre-decrement"
	srcY _ sy.
	dstY _ dy.
	srcShift _ (dx bitAnd: 1) * 16.
	destMSB ifTrue:[srcShift _ 16 - srcShift].
	mask1 _ 16rFFFF << (16 - srcShift).
	"This is the outer loop"
	[(deltaY _ deltaY - 1) ~= 0] whileTrue:[
		srcIndex _ sourceBits + (srcY * sourcePitch) + (sx * 4).
		dstIndex _ destBits + (dstY * destPitch) + (dx // 2 * 4).
		ditherBase _ (dstY bitAnd: 3) * 4.
		ditherIndex _ (sx bitAnd: 3) - 1. "For pre-increment"
		deltaX _ bbW + 1. "So we can pre-decrement"
		dstMask _ mask1.
		dstMask = 16rFFFF ifTrue:[srcShift _ 16] ifFalse:[srcShift _ 0].

		"This is the inner loop"
		[(deltaX _ deltaX - 1) ~= 0] whileTrue:[
			ditherThreshold _ ditherMatrix4x4 at: ditherBase + (ditherIndex _ ditherIndex + 1 bitAnd: 3).
			sourceWord _ self srcLongAt: srcIndex.
			srcAlpha _ sourceWord >> 24.
			srcAlpha = 255 ifTrue:[
				"Dither from 32 to 16 bit"
				sourceWord _ self dither32To16: sourceWord threshold: ditherThreshold.
				sourceWord = 0 
					ifTrue:[sourceWord _ 1 << srcShift]
					ifFalse: [sourceWord _ sourceWord << srcShift].
				"Store masked value"
				self dstLongAt: dstIndex put: sourceWord mask: dstMask.
			] ifFalse:[ "srcAlpha ~= 255"
				srcAlpha = 0 ifFalse:[ "0 < srcAlpha < 255"
					"If we have to mix colors then just copy a single word"
					destWord _ self dstLongAt: dstIndex.
					destWord _ destWord bitAnd: dstMask bitInvert32.
					destWord _ destWord >> srcShift.
					"Expand from 16 to 32 bit by adding zero bits"
					destWord _ (((destWord bitAnd: 16r7C00) bitShift: 9) bitOr:
									((destWord bitAnd: 16r3E0) bitShift: 6)) bitOr:
								(((destWord bitAnd: 16r1F) bitShift: 3) bitOr:
									16rFF000000).
					"Mix colors"
					sourceWord _ self alphaBlendScaled: sourceWord with: destWord.
					"And dither"
					sourceWord _ self dither32To16: sourceWord threshold: ditherThreshold.
					sourceWord = 0 
						ifTrue:[sourceWord _ 1 << srcShift]
						ifFalse:[sourceWord _ sourceWord << srcShift].
					"Store back"
					self dstLongAt: dstIndex put: sourceWord mask: dstMask.
				].
			].
			srcIndex _ srcIndex + 4.
			destMSB
				ifTrue:[srcShift = 0 ifTrue:[dstIndex _ dstIndex + 4]]
				ifFalse:[srcShift = 0 ifFalse:[dstIndex _ dstIndex + 4]].
			srcShift _ srcShift bitXor: 16. "Toggle between 0 and 16"
			dstMask _ dstMask bitInvert32. "Mask other half word"
		].
		srcY _ srcY + 1.
		dstY _ dstY + 1.
	].