primitiveGSMEncode

	| dstIndex dst srcIndex src frameCount state srcSize dstSize result srcDelta dstDelta |
	self export: true.
	dstIndex _ interpreterProxy stackIntegerValue: 0.
	dst _ interpreterProxy stackObjectValue: 1.
	srcIndex _ interpreterProxy stackIntegerValue: 2.
	src _ interpreterProxy stackObjectValue: 3.
	frameCount _ interpreterProxy stackIntegerValue: 4.
	state _ interpreterProxy stackObjectValue: 5.
	interpreterProxy success: (interpreterProxy isBytes: dst).
	interpreterProxy success: (interpreterProxy isWords: src).
	interpreterProxy success: (interpreterProxy isBytes: state).
	interpreterProxy failed ifTrue:[^ nil].
	srcSize _ (interpreterProxy slotSizeOf: src) * 2.
	dstSize _ interpreterProxy slotSizeOf: dst.
	self cCode: 'gsmEncode(state + 4, frameCount, src, srcIndex, srcSize, dst, dstIndex, dstSize, &srcDelta, &dstDelta)'.
	interpreterProxy failed ifTrue:[^ nil].
	result _ interpreterProxy makePointwithxValue: srcDelta yValue: dstDelta.
	interpreterProxy failed ifTrue:[^ nil].
	interpreterProxy pop: 6.
	interpreterProxy push: result.
