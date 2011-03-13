nextMatrix
	"Read a (possibly compressed) transformation matrix"
	| transform nBits |
	transform := MatrixTransform2x3 identity.
	self initBits.
	(self nextBits: 1) = 1 ifTrue:["Read a,d"
		nBits := self nextBits: 5.
		transform a11: (self nextSignedBits: nBits) / 65536.0.
		transform a22: (self nextSignedBits: nBits) / 65536.0].
	(self nextBits: 1) = 1 ifTrue:["Read b,c"
		nBits := self nextBits: 5.
		transform a21: (self nextSignedBits: nBits) / 65536.0.
		transform a12: (self nextSignedBits: nBits) / 65536.0].
	"Read tx, ty"
	nBits := self nextBits: 5.
	"Transcript cr; show:'nBits = ', nBits printString, ' from ', thisContext sender printString."
	transform a13: (self nextSignedBits: nBits) asFloat.
	transform a23: (self nextSignedBits: nBits) asFloat.
	^transform