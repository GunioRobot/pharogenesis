partitionedMax: word1 with: word2 nBits: nBits nPartitions: nParts
	"Max word1 to word2 as nParts partitions of nBits each"
	| mask result |
	mask _ (1 << nBits) - 1.  "partition mask starts at the right"
	result _ 0.
	1 to: nParts do:
		[:i |
		result _ result bitOr: ((word2 bitAnd: mask) max: (word1 bitAnd: mask)).
		mask _ mask << nBits  "slide left to next partition"].
	^ result
