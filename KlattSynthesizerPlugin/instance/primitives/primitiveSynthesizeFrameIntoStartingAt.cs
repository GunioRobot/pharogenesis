primitiveSynthesizeFrameIntoStartingAt
	| aKlattFrame buffer startIndex rcvr bufferOop |
	self export: true.
	self var: 'aKlattFrame' declareC: 'float *aKlattFrame'.
	self var: 'buffer' declareC: 'short *buffer'.
	aKlattFrame _ self checkedFloatPtrOf: (interpreterProxy stackValue: 2).
	buffer _ self checkedShortPtrOf: (bufferOop _ interpreterProxy stackValue: 1).
	startIndex _ interpreterProxy stackIntegerValue: 0.
	interpreterProxy failed ifTrue: [^nil].
	rcvr _ interpreterProxy stackObjectValue: 3.
	(self loadFrom: rcvr) ifFalse:[^nil].
	interpreterProxy success: (interpreterProxy stSizeOf: bufferOop) * 2 >= samplesPerFrame.
	interpreterProxy failed ifTrue: [^nil].
	self synthesizeFrame: aKlattFrame into: buffer startingAt: startIndex.
	(self saveTo: rcvr) ifFalse: [^nil].
	interpreterProxy pop: 3