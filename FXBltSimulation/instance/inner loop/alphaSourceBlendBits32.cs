alphaSourceBlendBits32
	"This version assumes 
		combinationRule = 34
		sourcePixSize = destPixSize = 32
		sourceForm ~= destForm.
	Note: The inner loop has been optimized for dealing
		with the special cases of srcAlpha = 0.0 and srcAlpha = 1.0 
	"
	| srcIndex dstIndex sourceWord srcAlpha destWord deltaX deltaY srcY dstY |
	self inline: false. "This particular method should be optimized in itself"

	"Give the compile a couple of hints"
	self var: #sourceWord declareC:'register int sourceWord'.
	self var: #deltaX declareC:'register int deltaX'.

	"The following should be declared as pointers so the compiler will
	notice that they're used for accessing memory locations 
	(good to know on an Intel architecture) but then the increments
	would be different between ST code and C code so must hope the
	compiler notices what happens (MS Visual C does)"
	self var: #srcIndex declareC:'register int srcIndex'.
	self var: #dstIndex declareC:'register int dstIndex'.

	deltaY _ bbH + 1. "So we can pre-decrement"
	srcY _ sy.
	dstY _ dy.

	"This is the outer loop"
	[(deltaY _ deltaY - 1) ~= 0] whileTrue:[
		srcIndex _ sourceBits + (srcY * sourcePitch) + (sx * 4).
		dstIndex _ destBits + (dstY * destPitch) + (dx * 4).
		deltaX _ bbW + 1. "So we can pre-decrement"

		"This is the inner loop"
		[(deltaX _ deltaX - 1) ~= 0] whileTrue:[
			sourceWord _ self srcLongAt: srcIndex.
			srcAlpha _ sourceWord >> 24.
			srcAlpha = 255 ifTrue:[
				self dstLongAt: dstIndex put: sourceWord.
				srcIndex _ srcIndex + 4.
				dstIndex _ dstIndex + 4.
				"Now copy as many words as possible with alpha = 255"
				[(deltaX _ deltaX - 1) ~= 0 and:[
					(sourceWord _ self srcLongAt: srcIndex) >> 24 = 255]]
						whileTrue:[
							self dstLongAt: dstIndex put: sourceWord.
							srcIndex _ srcIndex + 4.
							dstIndex _ dstIndex + 4.
						].
				"Adjust deltaX"
				deltaX _ deltaX + 1.
			] ifFalse:[ "srcAlpha ~= 255"
				srcAlpha = 0 ifTrue:[
					srcIndex _ srcIndex + 4.
					dstIndex _ dstIndex + 4.
					"Now skip as many words as possible,"
					[(deltaX _ deltaX - 1) ~= 0 and:[
						(sourceWord _ self srcLongAt: srcIndex) >> 24 = 0]]
						whileTrue:[
							srcIndex _ srcIndex + 4.
							dstIndex _ dstIndex + 4.
						].
					"Adjust deltaX"
					deltaX _ deltaX + 1.
				] ifFalse:[ "0 < srcAlpha < 255"
					"If we have to mix colors then just copy a single word"
					destWord _ self dstLongAt: dstIndex.
					destWord _ self alphaBlendScaled: sourceWord with: destWord.
					self dstLongAt: dstIndex put: destWord.
					srcIndex _ srcIndex + 4.
					dstIndex _ dstIndex + 4.
				].
			].
		].
		srcY _ srcY + 1.
		dstY _ dstY + 1.
	].