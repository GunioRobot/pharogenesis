partitionedSub: word1 from: word2 nBits: nBits nPartitions: nParts
	"Subtract word1 from word2 as nParts partitions of nBits each.
	This is useful for packed pixels, or packed colors"
	| mask result p1 p2 |
	mask _ (1 << nBits) - 1.  "partition mask starts at the right"
	result _ 0.
	1 to: nParts do:
		[:i |
		p1 _ word1 bitAnd: mask.
		p2 _ word2 bitAnd: mask.
		p1 < p2  "result is really abs value of thedifference"
			ifTrue: [result _ result bitOr: p2 - p1]
			ifFalse: [result _ result bitOr: p1 - p2].
		mask _ mask << nBits  "slide left to next partition"].
	^ result
