makeSuccessorMorph

	| newMorph |
	self fixAllLeftOffsets.
	newMorph _ self copy predecessor: self successor: successor.
	newMorph extent: self width @ 100.
	successor ifNotNil: [successor setPredecessor: newMorph].
	self setSuccessor: newMorph.
	successor recomposeChain.
	^newMorph