computeHuffmanValues: aCollection counts: counts from: minBits to: maxBits
	"Assign numerical values to all codes.
	Note: The values are stored according to the bit length"
	| offsets values baseOffset codeLength |
	offsets _ Array new: maxBits.
	offsets atAllPut: 0.
	baseOffset _ 1.
	minBits to: maxBits do:[:bits|
		offsets at: bits put: baseOffset.
		baseOffset _ baseOffset + (counts at: bits+1)].
	values _ WordArray new: aCollection size.
	1 to: aCollection size do:[:i|
		codeLength _ aCollection at: i.
		codeLength > 0 ifTrue:[
			baseOffset _ offsets at: codeLength.
			values at: baseOffset put: i-1.
			offsets at: codeLength put: baseOffset + 1]].
	^values