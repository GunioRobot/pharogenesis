processDynamicBlock
	| nLit nDist nLen codeLength lengthTable bits |
	nLit _ (self nextBits: 5) + 257.
	nDist _ (self nextBits: 5) + 1.
	nLen _ (self nextBits: 4) + 4.
	codeLength _ Array new: 19.
	codeLength atAllPut: 0.
	1 to: nLen do:[:i|
		bits _ #(16 17 18 0 8 7 9 6 10 5 11 4 12 3 13 2 14 1 15) at: i.
		codeLength at: bits+1 put: (self nextBits: 3).
	].
	lengthTable _ self huffmanTableFrom: codeLength mappedBy: nil.
	"RFC 1951: In other words, all code lengths form a single sequence..."
	codeLength _ self decodeDynamicTable: nLit+nDist from: lengthTable.
	litTable _ self 
				huffmanTableFrom: (codeLength copyFrom: 1 to: nLit)
				mappedBy: self literalLengthMap.
	distTable _ self 
				huffmanTableFrom: (codeLength copyFrom: nLit+1 to: codeLength size)
				mappedBy: self distanceMap.
	state _ state bitOr: BlockProceedBit.
	self proceedDynamicBlock.