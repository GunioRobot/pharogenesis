nextPointPut: aPoint
	"Write a (possibly compressed) point"
	self nextBits: 5 put: 31. "Always write full accuracy"
	self nextSignedBits: 31 put: aPoint x.
	self nextSignedBits: 31 put: aPoint y.
