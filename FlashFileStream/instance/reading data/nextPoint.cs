nextPoint
	"Read a (possibly compressed) point"
	| nBits point |
	nBits _ self nextBits: 5.
	point _ (self nextSignedBits: nBits) @ (self nextSignedBits: nBits).
	^point