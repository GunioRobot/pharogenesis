loadZipEncoderFrom: rcvr
	| oop |
	self inline: false.
	((interpreterProxy isPointers: rcvr) and:[
		(interpreterProxy slotSizeOf: rcvr) >= 6]) ifFalse:[^false].
	oop _ interpreterProxy fetchPointer: 0 ofObject: rcvr.
	(interpreterProxy isIntegerObject: oop)
		ifTrue:[^interpreterProxy primitiveFail].
	(interpreterProxy isBytes: oop)
		ifFalse:[^interpreterProxy primitiveFail].
	zipCollection _ interpreterProxy firstIndexableField: oop.
	zipCollectionSize _ interpreterProxy byteSizeOf: oop.

	zipPosition _ interpreterProxy fetchInteger: 1 ofObject: rcvr.
	zipReadLimit _ interpreterProxy fetchInteger: 2 ofObject: rcvr.
	"zipWriteLimit _ interpreterProxy fetchInteger: 3 ofObject: rcvr."
	zipBitBuf _ interpreterProxy fetchInteger: 4 ofObject: rcvr.
	zipBitPos _ interpreterProxy fetchInteger: 5 ofObject: rcvr.

	^interpreterProxy failed not