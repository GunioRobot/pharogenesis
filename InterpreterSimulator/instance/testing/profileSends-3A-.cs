profileSends: nBytecodes
	"(InterpreterSimulator new openOn: 'clonex.image') profileSends: 5000"
	Transcript clear.
	byteCount _ 0.
	MessageTally tallySendsTo: self inBlock: [
		self internalizeIPandSP.
		[byteCount < nBytecodes] whileTrue: [
			currentBytecode _ self fetchByte.
			self dispatchOn: currentBytecode in: BytecodeTable.
			byteCount _ byteCount + 1.
		].
		self externalizeIPandSP.
	] showTree: true.