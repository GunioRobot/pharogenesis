testIsPowerOfTwo

	self assert: (0 isPowerOfTwo).
	self assert: (1 isPowerOfTwo).
	self assert: (2 isPowerOfTwo).
	self deny:  (3 isPowerOfTwo).
	self assert: (4 isPowerOfTwo).
	