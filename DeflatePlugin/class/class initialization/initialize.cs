initialize
	"DeflatePlugin initialize"
	DeflateWindowSize _ 16r8000.
	DeflateWindowMask _ DeflateWindowSize - 1.
	DeflateMinMatch _ 3.
	DeflateMaxMatch _ 258.
	DeflateMaxDistance _ DeflateWindowSize.
	DeflateHashBits _ 15.
	DeflateHashTableSize _ 1 << DeflateHashBits.
	DeflateHashMask _ DeflateHashTableSize - 1.
	DeflateHashShift _ (DeflateHashBits + DeflateMinMatch - 1) // DeflateMinMatch.
	DeflateMaxLiteralCodes _ ZipWriteStream maxLiteralCodes.
	DeflateMaxDistanceCodes _ ZipWriteStream maxDistanceCodes.