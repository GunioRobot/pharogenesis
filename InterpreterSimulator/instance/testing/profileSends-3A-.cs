profileSends: nBytecodes
	"(InterpreterSimulator new openOn: 'clonex.image') profileSends: 5000"
	byteCount _ 0.
	MessageTally tallySendsTo: self inBlock: [
		self internalizeIPandSP.
		self fetchNextBytecode.
		[byteCount < nBytecodes] whileTrue:
			[self dispatchOn: currentBytecode in: BytecodeTable.
			byteCount _ byteCount + 1.
			byteCount \\ 100 = 0 ifTrue: [byteCount printString , '  ' displayAt: 0@0]].
		self externalizeIPandSP.
	] showTree: true.
	self close