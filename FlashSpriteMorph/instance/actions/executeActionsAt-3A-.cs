executeActionsAt: frame
	| rcvr actionList index msg result |
	actionList _ actions at: frame ifAbsent:[^self].
	index _ 1.
	rcvr _ self.
	[index <= actionList size] whileTrue:[
		msg _ actionList at: index.
"Transcript cr; print: msg selector; space; print: msg arguments; endEntry."
		msg selector == #actionTarget:
			ifTrue:[	rcvr _ msg sentTo: self]
			ifFalse:[	result _ msg sentTo: rcvr.
					result ifNotNil:[index _ index + result]].
		index _ index + 1].