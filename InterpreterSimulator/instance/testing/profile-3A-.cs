profile: nBytecodes
	"(InterpreterSimulator new openOn: 'clonex.image') profile: 60000"
	Transcript clear.
	byteCount _ 0.
	MessageTally spyOn: [
		self internalizeIPandSP.
		[byteCount < nBytecodes] whileTrue: [
			currentBytecode _ self fetchByte.
			self dispatchOn: currentBytecode in: BytecodeTable.
			byteCount _ byteCount + 1.
		].
		self externalizeIPandSP.
	].