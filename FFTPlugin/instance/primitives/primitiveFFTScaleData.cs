primitiveFFTScaleData
	| rcvr |
	self export: true.
	rcvr _ interpreterProxy stackObjectValue: 0.
	(self loadFFTFrom: rcvr) ifFalse:[^nil].
	self scaleData.