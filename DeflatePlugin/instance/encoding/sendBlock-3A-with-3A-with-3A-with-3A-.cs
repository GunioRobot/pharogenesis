sendBlock: literalStream with: distanceStream with: litTree with: distTree
	"Require: 
		zipCollection, zipCollectionSize, zipPosition,
		zipBitBuf, zipBitPos.
	"
	| oop litPos litLimit litArray distArray lit dist sum llBitLengths llCodes distBitLengths distCodes code extra litBlCount distBlCount |
	self var: #litArray declareC:'unsigned char *litArray'.
	self var: #distArray declareC:'unsigned int *distArray'.
	self var: #llBitLengths declareC:'unsigned int *llBitLengths'.
	self var: #llCodes declareC:'unsigned int *llCodes'.
	self var: #distBitLengths declareC:'unsigned int *distBitLengths'.
	self var: #distCodes declareC:'unsigned int *distCodes'.
	oop _ interpreterProxy fetchPointer: 0 ofObject: literalStream.
	litPos _ interpreterProxy fetchInteger: 1 ofObject: literalStream.
	litLimit _ interpreterProxy fetchInteger: 2 ofObject: literalStream.
	((interpreterProxy isIntegerObject: oop) not and:[litPos <= litLimit and:[
		litLimit <= (interpreterProxy byteSizeOf: oop) and:[interpreterProxy isBytes: oop]]])
			ifFalse:[^interpreterProxy primitiveFail].
	litArray _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 0 ofObject: distanceStream.
	((interpreterProxy isIntegerObject: oop) not and:[
		(interpreterProxy fetchInteger: 1 ofObject: distanceStream) = litPos and:[
			(interpreterProxy fetchInteger: 2 ofObject: distanceStream) = litLimit]])
				ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isWords: oop) and:[
		litLimit <= (interpreterProxy slotSizeOf: oop)])
			ifFalse:[^interpreterProxy primitiveFail].
	distArray _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 0 ofObject: litTree.
	((interpreterProxy isIntegerObject: oop) not and:[interpreterProxy isWords: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	litBlCount _ interpreterProxy slotSizeOf: oop.
	llBitLengths _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 1 ofObject: litTree.
	((interpreterProxy isIntegerObject: oop) not and:[interpreterProxy isWords: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	(litBlCount = (interpreterProxy slotSizeOf: oop))
		ifFalse:[^interpreterProxy primitiveFail].
	llCodes _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 0 ofObject: distTree.
	((interpreterProxy isIntegerObject: oop) not and:[interpreterProxy isWords: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	distBlCount _ interpreterProxy slotSizeOf: oop.
	distBitLengths _ interpreterProxy firstIndexableField: oop.

	oop _ interpreterProxy fetchPointer: 1 ofObject: distTree.
	((interpreterProxy isIntegerObject: oop) not and:[interpreterProxy isWords: oop])
		ifFalse:[^interpreterProxy primitiveFail].
	(distBlCount = (interpreterProxy slotSizeOf: oop))
		ifFalse:[^interpreterProxy primitiveFail].
	distCodes _ interpreterProxy firstIndexableField: oop.

	interpreterProxy failed ifTrue:[^nil].

	self nextZipBits: 0 put: 0. "Flush pending bits if necessary"
	sum _ 0.
	[litPos < litLimit and:[zipPosition + 4 < zipCollectionSize]] whileTrue:[
		lit _ litArray at: litPos.
		dist _ distArray at: litPos.
		litPos _ litPos + 1.
		dist = 0 ifTrue:["literal"
			sum _ sum + 1.
			lit < litBlCount ifFalse:[^interpreterProxy primitiveFail].
			self nextZipBits: (llBitLengths at: lit) put: (llCodes at: lit).
		] ifFalse:["match"
			sum _ sum + lit + DeflateMinMatch.
			lit < 256 ifFalse:[^interpreterProxy primitiveFail].
			code _ zipMatchLengthCodes at: lit.
			code < litBlCount ifFalse:[^interpreterProxy primitiveFail].
			self nextZipBits: (llBitLengths at: code) put: (llCodes at: code).
			extra _ zipExtraLengthBits at: code - 257.
			extra = 0 ifFalse:[
				lit _ lit - (zipBaseLength at: code - 257).
				self nextZipBits: extra put: lit].
			dist _ dist - 1.
			dist < 16r8000 ifFalse:[^interpreterProxy primitiveFail].
			dist < 256
				ifTrue:[code _ zipDistanceCodes at: dist]
				ifFalse:[code _ zipDistanceCodes at: 256 + (dist >> 7)].
			code < distBlCount ifFalse:[^interpreterProxy primitiveFail].
			self nextZipBits: (distBitLengths at: code) put: (distCodes at: code).
			extra _ zipExtraDistanceBits at: code.
			extra = 0 ifFalse:[
				dist _ dist - (zipBaseDistance at: code).
				self nextZipBits: extra put: dist].
		].
	].
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy storeInteger: 1 ofObject: literalStream withValue: litPos.
	interpreterProxy storeInteger: 1 ofObject: distanceStream withValue: litPos.
	^sum