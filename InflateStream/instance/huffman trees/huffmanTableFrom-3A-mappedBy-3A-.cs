huffmanTableFrom: aCollection mappedBy: valueMap
	"Create a new huffman table from the given code lengths.
	Map the actual values by valueMap if it is given.
	See the class comment for a documentation of the huffman
	tables used in this decompressor."
	| counts  values table minBits maxBits |
	minBits _ MaxBits + 1.
	maxBits _ 0.
	"Count the occurences of each code length and compute minBits and maxBits"
	counts _ Array new: MaxBits+1.
	counts atAllPut: 0.
	aCollection do:[:length| 
		length > 0 ifTrue:[
			length < minBits ifTrue:[minBits _ length].
			length > maxBits ifTrue:[maxBits _ length].
			counts at: length+1 put: (counts at: length+1)+1]].
	maxBits = 0 ifTrue:[^nil]. "Empty huffman table"

	"Assign numerical values to all codes."
	values _ self computeHuffmanValues: aCollection counts: counts from: minBits to: maxBits.

	"Map the values if requested"
	self mapValues: values by: valueMap.

	"Create the actual tables"
	table _ self createHuffmanTables: values counts: counts from: minBits to: maxBits.

	^table