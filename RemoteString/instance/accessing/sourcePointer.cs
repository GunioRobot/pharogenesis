sourcePointer
	sourceFileNumber ifNil: [^ 0].
	^ (sourceFileNumber * 16r1000000) + filePositionHi