addPredecessor: evt
	| newMorph |
	newMorph _ TextMorph new text: text textStyle: textStyle wrap: wrapFlag
			color: color predecessor: predecessor successor: self.
	newMorph extent: self width @ 100.
	predecessor ifNotNil: [predecessor setSuccessor: newMorph].
	self setPredecessor: newMorph.
	predecessor recomposeChain.
	evt hand attachMorph: newMorph