jpegDecodeValueFrom: table size: tableSize
	"Decode the next value in the receiver using the given huffman table."
	| bits bitsNeeded tableIndex value index |
	self var: #table declareC:'int *table'.
	bitsNeeded _ (table at: 0) >> 24.	"Initial bits needed"
	bitsNeeded > MaxBits ifTrue:[^-1].
	tableIndex _ 2.							"First real table"
	[true] whileTrue:[
		bits _ self getBits: bitsNeeded.		"Get bits"
		bits < 0 ifTrue:[^-1].
		index _ tableIndex + bits - 1.
		index >= tableSize ifTrue:[^-1].
		value _ table at: index.					"Lookup entry in table"
		(value bitAnd: 16r3F000000) = 0 ifTrue:[^value]. "Check if it is a leaf node"
		"Fetch sub table"
		tableIndex _ value bitAnd: 16rFFFF.	"Table offset in low 16 bit"
		bitsNeeded _ (value >> 24) bitAnd: 255. "Additional bits in high 8 bit"
		bitsNeeded > MaxBits ifTrue:[^-1]].
	^-1