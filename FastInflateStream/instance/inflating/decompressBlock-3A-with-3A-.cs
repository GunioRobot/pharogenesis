decompressBlock: llTable with: dTable
	"Process the compressed data in the block.
	llTable is the huffman table for literal/length codes
	and dTable is the huffman table for distance codes."
	| value extra length distance oldPos oldBits oldBitPos |
	<primitive: 'primitiveInflateDecompressBlock' module: 'ZipPlugin'>
	[readLimit < collection size and:[sourcePos <= sourceLimit]] whileTrue:[
		"Back up stuff if we're running out of space"
		oldBits _ bitBuf.
		oldBitPos _ bitPos.
		oldPos _ sourcePos.
		value _ self decodeValueFrom: llTable.
		value < 256 ifTrue:[ "A literal"
			collection byteAt: (readLimit _ readLimit + 1) put: value.
		] ifFalse:["length/distance or end of block"
			value = 256 ifTrue:["End of block"
				state _ state bitAnd: StateNoMoreData.
				^self].
			"Compute the actual length value (including possible extra bits)"
			extra _ (value bitShift: -16) - 1.
			length _ value bitAnd: 16rFFFF.
			extra > 0 ifTrue:[length _ length + (self nextBits: extra)].
			"Compute the distance value"
			value _ self decodeValueFrom: dTable.
			extra _ (value bitShift: -16).
			distance _ value bitAnd: 16rFFFF.
			extra > 0 ifTrue:[distance _ distance + (self nextBits: extra)].
			(readLimit + length >= collection size) ifTrue:[
				bitBuf _ oldBits.
				bitPos _ oldBitPos.
				sourcePos _ oldPos.
				^self].
			collection 
					replaceFrom: readLimit+1 
					to: readLimit + length + 1 
					with: collection 
					startingAt: readLimit - distance + 1.
			readLimit _ readLimit + length.
		].
	].