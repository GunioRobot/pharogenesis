primitiveCopyBuffer
	| buf1 buf2 diff src dst |
	self export: true.
	self inline: false.

	self var: #src declareC:'int * src'.
	self var: #dst declareC:'int * dst'.

	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].

	buf2 _ interpreterProxy stackObjectValue: 0.
	buf1 _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	"Make sure the old buffer is properly initialized"
	(self loadWorkBufferFrom: buf1) 
		ifFalse:[^interpreterProxy primitiveFail].
	"Make sure the buffers are of the same type"
	(interpreterProxy fetchClassOf: buf1) = (interpreterProxy fetchClassOf: buf2)
		ifFalse:[^interpreterProxy primitiveFail].
	"Make sure buf2 is at least of the size of buf1"
	diff _ (interpreterProxy slotSizeOf: buf2) - (interpreterProxy slotSizeOf: buf1).
	diff < 0 ifTrue:[^interpreterProxy primitiveFail].

	"Okay - ready for copying. First of all just copy the contents up to wbTop"
	src _ workBuffer.
	dst _ interpreterProxy firstIndexableField: buf2.
	0 to: self wbTopGet-1 do:[:i|
		dst at: i put: (src at: i).
	].
	"Adjust wbSize and wbTop in the new buffer"
	dst at: GWBufferTop put: self wbTopGet + diff.
	dst at: GWSize put: self wbSizeGet + diff.
	"Now copy the entries from wbTop to wbSize"
	src _ src + self wbTopGet.
	dst _ dst + self wbTopGet + diff.
	0 to: (self wbSizeGet - self wbTopGet - 1) do:[:i|
		dst at: i put: (src at: i).
	].
	"Okay, done. Check the new buffer by loading the state from it"
	(self loadWorkBufferFrom: buf2) 
		ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 2. "Leave rcvr on stack"
