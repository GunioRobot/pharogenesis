dstLongAt: dstIndex
	interpreterProxy isInterpreterProxy
		ifTrue:[^dstIndex longAt: 0].
	((dstIndex anyMask: 3) or:[dstIndex + 4 < destBits or:[
		dstIndex > (destBits + (destPitch * destHeight))]])
			ifTrue:[self error:'Out of bounds'].
	^interpreterProxy longAt: dstIndex