nextRectPut: aRect
	"Write a (possibly compressed) rectangle"
	self nextBits: 5 put: 31. "Always use full accuracy"
	self nextSignedBits: 31 put: aRect origin x.
	self nextSignedBits: 31 put: aRect corner x.
	self nextSignedBits: 31 put: aRect origin y.
	self nextSignedBits: 31 put: aRect corner y.