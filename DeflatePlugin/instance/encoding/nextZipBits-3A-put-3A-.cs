nextZipBits: nBits put: value
	"Require:
		zipCollection, zipCollectionSize, zipPosition,
		zipBitBuf, zipBitPos.
	"
	self inline: true.
	(value >= 0 and:[(1 << nBits) > value])
		ifFalse:[^interpreterProxy primitiveFail].
	zipBitBuf _ zipBitBuf bitOr: (value bitShift: zipBitPos).
	zipBitPos _ zipBitPos + nBits.
	[zipBitPos >= 8 and:[zipPosition < zipCollectionSize]] whileTrue:[
		zipCollection at: zipPosition put: (zipBitBuf bitAnd: 255).
		zipPosition _ zipPosition + 1.
		zipBitBuf _ zipBitBuf >> 8.
		zipBitPos _ zipBitPos - 8].
