setupColorMasks
	| bits targetBits |
	bits _ targetBits _ 0.
	sourcePixSize <= 8 ifTrue:[^nil].
	sourcePixSize = 16 ifTrue:[bits _ 5].
	sourcePixSize = 32 ifTrue:[bits _ 8].

	colorMap == nil
		ifTrue:["Convert between RGB values"
				destPixSize <= 8 ifTrue:[^nil].
				destPixSize = 16 ifTrue:[targetBits _ 5].
				destPixSize = 32 ifTrue:[targetBits _ 8]]
		ifFalse:[targetBits _ cmBitsPerColor].

	self setupColorMasksFrom: bits to: targetBits