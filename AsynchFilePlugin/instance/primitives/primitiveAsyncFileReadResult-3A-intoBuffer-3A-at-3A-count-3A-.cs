primitiveAsyncFileReadResult: fhandle intoBuffer: buffer at: start count: num 
	| bufferSize bufferPtr r f count startIndex |
	self var: #f declareC: 'AsyncFile *f'.
	self primitive: 'primitiveAsyncFileReadResult' parameters: #(Oop Oop SmallInteger SmallInteger ).

	f _ self asyncFileValueOf: fhandle.
	count _ num.
	startIndex _ start.
	bufferSize _ interpreterProxy slotSizeOf: buffer. "in bytes or words"
	(interpreterProxy isWords: buffer)
		ifTrue: ["covert word counts to byte counts"
			count _ count * 4.
			startIndex _ startIndex - 1 * 4 + 1.
			bufferSize _ bufferSize * 4].
	interpreterProxy success: (startIndex >= 1 and: [startIndex + count - 1 <= bufferSize]).

	bufferPtr _ (self cCoerce: (interpreterProxy firstIndexableField: buffer) to: 'int') + startIndex - 1. 	"adjust for zero-origin indexing"
	interpreterProxy failed ifFalse: [r _ self cCode: 'asyncFileReadResult(f, bufferPtr, count)'].
	^ r asOop: SmallInteger