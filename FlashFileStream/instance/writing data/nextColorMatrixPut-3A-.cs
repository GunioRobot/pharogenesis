nextColorMatrixPut: cm
	"Write a (possibly compressed) color transformation"
	self flushBits.
	self nextBits: 2 put: 3. "Always write full transform"
	self nextBits: 4 put: 15. "Always use full accuracy"
	self nextSignedBits: 15 put: cm rMul.
	self nextSignedBits: 15 put: cm gMul.
	self nextSignedBits: 15 put: cm bMul.
	hasAlpha ifTrue:[self nextSignedBits: 15 put: cm aMul].
	self nextSignedBits: 15 put: cm rAdd.
	self nextSignedBits: 15 put: cm gAdd.
	self nextSignedBits: 15 put: cm bAdd.
	hasAlpha ifTrue:[self nextSignedBits: 15 put: cm aAdd].