zipDecompressBlock
	| value extra length distance oldPos oldBits oldBitPos dstPos srcPos max |
	self inline: false.
	max _ zipCollectionSize - 1.
	[zipReadLimit < max and:[zipSourcePos <= zipSourceLimit]] whileTrue:[
		"Back up stuff if we're running out of space"
		oldBits _ zipBitBuf.
		oldBitPos _ zipBitPos.
		oldPos _ zipSourcePos.
		value _ self zipDecodeValueFrom: zipLitTable size: zipLitTableSize.
		value < 256 ifTrue:[ "A literal"
			zipCollection at: (zipReadLimit _ zipReadLimit + 1) put: value.
		] ifFalse:["length/distance or end of block"
			value = 256 ifTrue:["End of block"
				zipState _ zipState bitAnd: StateNoMoreData.
				^0].
			"Compute the actual length value (including possible extra bits)"
			extra _ (value bitShift: -16) - 1.
			length _ value bitAnd: 16rFFFF.
			extra > 0 ifTrue:[length _ length + (self zipNextBits: extra)].
			"Compute the distance value"
			value _ self zipDecodeValueFrom: zipDistTable size: zipDistTableSize.
			extra _ (value bitShift: -16).
			distance _ value bitAnd: 16rFFFF.
			extra > 0 ifTrue:[distance _ distance + (self zipNextBits: extra)].
			(zipReadLimit + length >= max) ifTrue:[
				zipBitBuf _ oldBits.
				zipBitPos _ oldBitPos.
				zipSourcePos _ oldPos.
				^0].
			dstPos _ zipReadLimit.
			srcPos _ zipReadLimit - distance.
			1 to: length do:[:i|
				zipCollection at: dstPos+i put: (zipCollection at: srcPos+i)].
			zipReadLimit _ zipReadLimit + length.
		].
	].