zipNextBits: n
	| bits byte |
	self inline: true.
	[zipBitPos < n] whileTrue:[
		byte _ zipSource at: (zipSourcePos _ zipSourcePos + 1).
		zipBitBuf _ zipBitBuf + (byte << zipBitPos).
		zipBitPos _ zipBitPos + 8].
	bits _ zipBitBuf bitAnd: (1 << n)-1.
	zipBitBuf _ zipBitBuf >> n.
	zipBitPos _ zipBitPos - n.
	^bits