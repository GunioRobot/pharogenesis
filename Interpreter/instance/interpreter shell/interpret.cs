interpret

	self internalizeIPandSP.
	[true] whileTrue: [
		currentBytecode _ self fetchByte.
		self dispatchOn: currentBytecode in: BytecodeTable.
	].
	self externalizeIPandSP.
