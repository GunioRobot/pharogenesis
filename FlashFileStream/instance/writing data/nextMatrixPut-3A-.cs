nextMatrixPut: matrix
	"write a (possibly compressed) transformation matrix"
	self flushBits.
	(matrix a11 = 0.0 and:[matrix  a22 = 0.0]) ifFalse:[
		"Write a/d"
		self nextBits: 1 put: 1.
		self nextBits: 5 put: 31. "Always use full accuracy"
		self nextSignedBits: 31 put: matrix a11 * 65536.
		self nextSignedBits: 31 put: matrix a22 * 65536.
	] ifTrue:[self nextBits: 1 put: 0].
	((matrix a12) = 0.0 and:[(matrix  a21) = 0.0]) ifFalse:[
		"Write b/c"
		self nextBits: 1 put: 1.
		self nextBits: 5 put: 31. "Always use full accuracy"
		self nextSignedBits: 31 put: matrix a12 * 65536.
		self nextSignedBits: 31 put: matrix a21 * 65536.
	] ifTrue:[self nextBits: 1 put: 0].
	"Write tx/ty"
	self nextBits: 5 put: 31. "Always use full accuracy"
	self nextSignedBits: 31 put: matrix a13.
	self nextSignedBits: 31 put: matrix a23.
