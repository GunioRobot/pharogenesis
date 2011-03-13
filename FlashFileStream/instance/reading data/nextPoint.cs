nextPoint
	"Read a (possibly compressed) point"
	| nBits point |
	nBits := self nextBits: 5.
	point := (self nextSignedBits: nBits) @ (self nextSignedBits: nBits).
	^point