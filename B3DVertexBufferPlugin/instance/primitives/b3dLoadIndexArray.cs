b3dLoadIndexArray
	"Primitive. Load the given index array into the receiver.
	NOTE: dstStart is a zero-based index."
	| vtxOffset maxValue count srcArray srcPtr idx dstStart dstArray dstSize dstPtr |
	self export: true.
	self inline: false.
	self var: #dstPtr declareC:'int *dstPtr'.
	self var: #srcPtr declareC:'int *srcPtr'.
	"Load the arguments"
	vtxOffset _ interpreterProxy stackIntegerValue: 0.
	maxValue _ interpreterProxy stackIntegerValue: 1.
	count _ interpreterProxy stackIntegerValue: 2.
	srcArray _ interpreterProxy stackObjectValue: 3.
	dstStart _ interpreterProxy stackIntegerValue: 4.
	dstArray _ interpreterProxy stackObjectValue: 5.
	interpreterProxy failed ifTrue:[^nil]. "Will cover all possible problems above"
	"Check srcArray"
	(interpreterProxy isWords: srcArray)
		ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy slotSizeOf: srcArray) < count)
		ifTrue:[^interpreterProxy primitiveFail].
	srcPtr _ self cCoerce: (interpreterProxy firstIndexableField: srcArray) to:'int*'.
	"Check dstArray"
 	dstSize _ interpreterProxy slotSizeOf: dstArray.
	"Check if there is enough room left in dstArray"
	dstStart + count > dstSize
		ifTrue:[^interpreterProxy primitiveFail].
	dstPtr _ self cCoerce: (interpreterProxy firstIndexableField: dstArray) to:'int *'.
	"Do the actual work"
	0 to: count-1 do:[:i|
		idx _ srcPtr at: i.
		(idx < 1 or:[idx > maxValue]) 
			ifTrue:[^interpreterProxy primitiveFail].
		dstPtr at: dstStart + i put: idx + vtxOffset.
	].
	"Clean up the stack"
	interpreterProxy pop: 7. "Pop args+rcvr"
	interpreterProxy pushInteger: count.
