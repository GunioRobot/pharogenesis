loadDeflateStreamFrom: rcvr
	| oop |
	self inline: false.
	((interpreterProxy isPointers: rcvr) and:[
		(interpreterProxy slotSizeOf: rcvr) >= 15]) ifFalse:[^false].
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

	oop _ interpreterProxy fetchPointer: 4 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isWords: oop) not]) ifTrue:[^false].
	(interpreterProxy slotSizeOf: oop) = DeflateHashTableSize ifFalse:[^false].
	zipHashHead _ interpreterProxy firstIndexableField: oop.
	oop _ interpreterProxy fetchPointer: 5 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isWords: oop) not]) ifTrue:[^false].
	(interpreterProxy slotSizeOf: oop) = DeflateWindowSize ifFalse:[^false].
	zipHashTail _ interpreterProxy firstIndexableField: oop.
	zipHashValue _ interpreterProxy fetchInteger: 6 ofObject: rcvr.
	zipBlockPos _ interpreterProxy fetchInteger: 7 ofObject: rcvr.
	"zipBlockStart _ interpreterProxy fetchInteger: 8 ofObject: rcvr."
	oop _ interpreterProxy fetchPointer: 9 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isBytes: oop) not]) ifTrue:[^false].
	zipLiteralSize _ interpreterProxy slotSizeOf: oop.
	zipLiterals _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 10 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isWords: oop) not]) ifTrue:[^false].
	(interpreterProxy slotSizeOf: oop) < zipLiteralSize ifTrue:[^false].
	zipDistances _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 11 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isWords: oop) not]) ifTrue:[^false].
	(interpreterProxy slotSizeOf: oop) = DeflateMaxLiteralCodes ifFalse:[^false].
	zipLiteralFreq _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 12 ofObject: rcvr.
	((interpreterProxy isIntegerObject: oop) or:[
		(interpreterProxy isWords: oop) not]) ifTrue:[^false].
	(interpreterProxy slotSizeOf: oop) = DeflateMaxDistanceCodes ifFalse:[^false].
	zipDistanceFreq _ interpreterProxy firstIndexableField: oop.

	zipLiteralCount _ interpreterProxy fetchInteger: 13 ofObject: rcvr.
	zipMatchCount _ interpreterProxy fetchInteger: 14 ofObject: rcvr.

	^interpreterProxy failed not