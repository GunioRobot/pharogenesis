flushBits
	remainBitCount = 0 ifFalse:
		[self nextBytePut: bufByte.
		remainBitCount _ 0].
	self flushBuffer