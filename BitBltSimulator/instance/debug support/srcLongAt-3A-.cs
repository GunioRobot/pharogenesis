srcLongAt: srcIndex
	interpreterProxy isInterpreterProxy
		ifTrue:[^srcIndex longAt: 0].
	((srcIndex anyMask: 3) or:[srcIndex + 4 < sourceBits or:[
		srcIndex > (sourceBits + (sourcePitch * sourceHeight))]])
			ifTrue:[self error:'Out of bounds'].
	^interpreterProxy longAt: srcIndex