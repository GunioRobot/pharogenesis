parseHuffmanTable

	| length markerStart index bits count huffVal isACTable hTable |
	markerStart _ self position.
	length _ self nextWord.
	[self position - markerStart >= length] whileFalse:
		[index _ self next.
		isACTable _ (index bitAnd: 16r10) ~= 0.
		index _ (index bitAnd: 16r0F) + 1.
		index > HuffmanTableSize
			ifTrue: [self error: 'image has more than ', HuffmanTableSize printString,
				' quantization tables'].
		bits _ self next: 16.
		count _ bits sum.
		(count > 256 or: [(count > (length - (self position - markerStart)))])
			ifTrue: [self error: 'Huffman Table count is incorrect'].
		huffVal _ self next: count.
		hTable _ stream buildLookupTable: huffVal counts: bits.
		isACTable
			ifTrue:
				[self hACTable at: index put: hTable]
			ifFalse:
				[self hDCTable at: index put: hTable]].