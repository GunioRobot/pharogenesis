step

	(self ownerThatIsA: HandMorph) ifNotNil: [^self].
	paused ifTrue: [^ self]. 
	currentBlock ifNil: [
		currentBlock _ TetrisBlock new.
		self addMorphFront: currentBlock.
		currentBlock board: self.
	] ifNotNil: [
		currentBlock dropByOne ifFalse: [self storePieceOnBoard]
	].
