addSuccessor: evt
	| newMorph |
	newMorph _ TextMorph new text: text textStyle: textStyle wrap: wrapFlag
			color: color predecessor: self successor: successor.
	newMorph extent: self width @ 100.
	successor ifNotNil: [successor setPredecessor: newMorph].
	self setSuccessor: newMorph.
	successor recomposeChain.
	evt hand attachMorph: newMorph