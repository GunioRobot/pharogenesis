primitiveInflateDecompressBlock
	"Primitive. Inflate a single block."
	| oop rcvr |
	self export: true.
	interpreterProxy methodArgumentCount = 2 ifFalse:[^interpreterProxy primitiveFail].
	"distance table"
	oop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	zipDistTable _ interpreterProxy firstIndexableField: oop.
	zipDistTableSize _ interpreterProxy slotSizeOf: oop.

	"literal table"
	oop _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	zipLitTable _ interpreterProxy firstIndexableField: oop.
	zipLitTableSize _ interpreterProxy slotSizeOf: oop.


	"Receiver (InflateStream)"
	rcvr _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isPointers: rcvr)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: rcvr) < 9
		ifTrue:[^interpreterProxy primitiveFail].

	"All the integer instvars"
	zipReadLimit _ interpreterProxy fetchInteger: 2 ofObject: rcvr.
	zipState _ interpreterProxy fetchInteger: 3 ofObject: rcvr.
	zipBitBuf _ interpreterProxy fetchInteger: 4 ofObject: rcvr.
	zipBitPos _ interpreterProxy fetchInteger: 5 ofObject: rcvr.
	zipSourcePos _ interpreterProxy fetchInteger: 7 ofObject: rcvr.
	zipSourceLimit _ interpreterProxy fetchInteger: 8 ofObject: rcvr.
	interpreterProxy failed ifTrue:[^nil].
	zipReadLimit _ zipReadLimit - 1.
	zipSourcePos _ zipSourcePos - 1.
	zipSourceLimit _ zipSourceLimit - 1.

	"collection"
	oop _ interpreterProxy fetchPointer: 0 ofObject: rcvr.
	(interpreterProxy isIntegerObject: oop)
		ifTrue:[^interpreterProxy primitiveFail].
	(interpreterProxy isBytes: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	zipCollection _ interpreterProxy firstIndexableField: oop.
	zipCollectionSize _ interpreterProxy byteSizeOf: oop.

	"source"
	oop _ interpreterProxy fetchPointer: 6 ofObject: rcvr.
	(interpreterProxy isIntegerObject: oop)
		ifTrue:[^interpreterProxy primitiveFail].
	(interpreterProxy isBytes: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	zipSource _ interpreterProxy firstIndexableField: oop.

	"do the primitive"
	self zipDecompressBlock.
	interpreterProxy failed ifFalse:[
		"store modified values back"
		interpreterProxy storeInteger: 2 ofObject: rcvr withValue: zipReadLimit + 1.
		interpreterProxy storeInteger: 3 ofObject: rcvr withValue: zipState.
		interpreterProxy storeInteger: 4 ofObject: rcvr withValue: zipBitBuf.
		interpreterProxy storeInteger: 5 ofObject: rcvr withValue: zipBitPos.
		interpreterProxy storeInteger: 7 ofObject: rcvr withValue: zipSourcePos + 1.
		interpreterProxy pop: 2.
	].