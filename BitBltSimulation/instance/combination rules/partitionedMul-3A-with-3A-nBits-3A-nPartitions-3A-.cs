partitionedMul: word1 with: word2 nBits: nBits nPartitions: nParts
	"Multiply word1 with word2 as nParts partitions of nBits each.
	This is useful for packed pixels, or packed colors.
	Bug in loop version when non-white background"

	| sMask product result dMask |
	sMask _ maskTable at: nBits.  "partition mask starts at the right"
	dMask _  sMask << nBits.
	result _ (((word1 bitAnd: sMask)+1) * ((word2 bitAnd: sMask)+1) - 1 
				bitAnd: dMask) >> nBits.	"optimized first step"
	product _ (((word1>>nBits bitAnd: sMask)+1) * ((word2>>nBits bitAnd: sMask)+1) - 1 bitAnd: dMask).
	result _ result bitOr: (product bitAnd: dMask).
	product _ (((word1>>(2*nBits) bitAnd: sMask)+1) * ((word2>>(2*nBits) bitAnd: sMask)+1) - 1 bitAnd: dMask).
	result _ result bitOr: (product bitAnd: dMask) << nBits.
	^ result


"	| sMask product result dMask |
	sMask _ maskTable at: nBits.  'partition mask starts at the right'
	dMask _  sMask << nBits.
	result _ (((word1 bitAnd: sMask)+1) * ((word2 bitAnd: sMask)+1) - 1 
				bitAnd: dMask) >> nBits.	'optimized first step'
	nBits to: nBits * (nParts-1) by: nBits do: [:ofs |
		product _ (((word1>>ofs bitAnd: sMask)+1) * ((word2>>ofs bitAnd: sMask)+1) - 1 bitAnd: dMask).
		result _ result bitOr: (product bitAnd: dMask) << (ofs-nBits)].
	^ result"