test

	Transcript clear.
	byteCount _ 0.
	self internalizeIPandSP.
	[true] whileTrue: [
		currentBytecode _ self fetchByte.
		self dispatchOn: currentBytecode in: BytecodeTable.
		byteCount _ byteCount + 1.
	].
	self externalizeIPandSP.
