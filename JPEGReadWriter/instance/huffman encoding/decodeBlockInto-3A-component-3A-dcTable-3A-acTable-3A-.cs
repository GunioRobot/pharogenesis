decodeBlockInto: anArray component: aColorComponent dcTable: huffmanDC acTable: huffmanAC

	| byte i zeroCount |
	byte _ self decodeByteWithTable: huffmanDC.
	byte ~= 0 ifTrue: [byte _ self scaleAndSignExtend: ( self getBits: byte) inFieldWidth: byte].
	byte _ aColorComponent updateDCValue: byte.
	anArray atAllPut: 0.
	anArray at: 1 put: byte.
	i _ 2.
	[i <= DCTSize2] whileTrue:
		[byte _ self decodeByteWithTable: huffmanAC.
		zeroCount _ byte >> 4.
		byte _ byte bitAnd: 16r0F.
		byte ~= 0
			ifTrue:
				[i _ i + zeroCount.
				byte _ self scaleAndSignExtend: ( self getBits: byte) inFieldWidth: byte.
				anArray at:	 (JPEGNaturalOrder at: i) put: byte]
			ifFalse:
				[zeroCount = 15 ifTrue: [i _ i + zeroCount] ifFalse: [^ self]].
		i _ i + 1]
		