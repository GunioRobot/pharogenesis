setupColorMasks
	"WARNING: For WarpBlt w/ smoothing the source depth is wrong here!"
	| bits targetBits |
	bits _ targetBits _ 0.
	sourceDepth <= 8 ifTrue:[^nil].
	sourceDepth = 16 ifTrue:[bits _ 5].
	sourceDepth = 32 ifTrue:[bits _ 8].

	cmBitsPerColor = 0
		ifTrue:["Convert to destDepth"
				destDepth <= 8 ifTrue:[^nil].
				destDepth = 16 ifTrue:[targetBits _ 5].
				destDepth = 32 ifTrue:[targetBits _ 8]]
		ifFalse:[targetBits _ cmBitsPerColor].

	self setupColorMasksFrom: bits to: targetBits