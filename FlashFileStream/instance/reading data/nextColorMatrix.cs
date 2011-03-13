nextColorMatrix
	"Read a (possibly compressed) color transformation"
	| transform nBits flags |
	transform := FlashColorTransform new.
	self initBits.
	flags := self nextBits: 2.
	nBits := self nextBits: 4.
	(flags anyMask: 1) ifTrue:["Read multiplication factors"
		transform rMul: (self nextSignedBits: nBits) / 256.0.
		transform gMul: (self nextSignedBits: nBits) / 256.0.
		transform bMul: (self nextSignedBits: nBits) / 256.0.
		hasAlpha ifTrue:[transform aMul: (self nextSignedBits: nBits) / 256.0]].
	(flags anyMask: 2) ifTrue:["Read multiplication factors"
		transform rAdd: (self nextSignedBits: nBits) / 256.0.
		transform gAdd: (self nextSignedBits: nBits) / 256.0.
		transform bAdd: (self nextSignedBits: nBits) / 256.0.
		hasAlpha ifTrue:[transform aAdd: (self nextSignedBits: nBits) / 256.0]].
	^transform