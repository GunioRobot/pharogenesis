dstLongAt: dstIndex put: value
	interpreterProxy isInterpreterProxy
		ifTrue:[^dstIndex longAt: 0 put: value].
	((dstIndex anyMask: 3) or:[dstIndex < destBits or:[
		dstIndex >= (destBits + (destPitch * destHeight))]])
			ifTrue:[self error:'Out of bounds'].
	^interpreterProxy longAt: dstIndex put: value