processFixedBlock
	litTable _ self 
				huffmanTableFrom: FixedLitCodes
				mappedBy: self literalLengthMap.
	distTable _ self 
				huffmanTableFrom: FixedDistCodes
				mappedBy: self distanceMap.
	state _ state bitOr: BlockProceedBit.
	self proceedFixedBlock.