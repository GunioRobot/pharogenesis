decodeValueFrom: table
	"Decode the next value in the receiver using the given huffman table."
	| bits bitsNeeded tableIndex value |
	bitsNeeded _ (table at: 1) bitShift: -24.	"Initial bits needed"
	tableIndex _ 2.							"First real table"
	[bits _ self getBits: bitsNeeded.			"Get bits"
	value _ table at: (tableIndex + bits).		"Lookup entry in table"
	(value bitAnd: 16r3F000000) = 0] 			"Check if it is a non-leaf node"
		whileFalse:["Fetch sub table"
			tableIndex _ value bitAnd: 16rFFFF.	"Table offset in low 16 bit"
			bitsNeeded _ (value bitShift: -24) bitAnd: 255. "Additional bits in high 8 bit"
			bitsNeeded > MaxBits ifTrue:[^self error:'Invalid huffman table entry']].
	^value