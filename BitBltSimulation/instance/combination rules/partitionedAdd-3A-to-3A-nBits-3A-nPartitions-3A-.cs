partitionedAdd: word1 to: word2 nBits: nBits nPartitions: nParts
	"Add word1 to word2 as nParts partitions of nBits each.
	This is useful for packed pixels, or packed colors"
	| mask sum result |
	mask _ (1 << nBits) - 1.  "partition mask starts at the right"
	result _ 0.
	1 to: nParts do:
		[:i |
		sum _ (word1 bitAnd: mask) + (word2 bitAnd: mask).
		sum <= mask  "result must not carry out of partition"
			ifTrue: [result _ result bitOr: sum]
			ifFalse: [result _ result bitOr: mask].
		mask _ mask << nBits  "slide left to next partition"].
	^ result
