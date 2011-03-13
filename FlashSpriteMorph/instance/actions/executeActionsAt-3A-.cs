executeActionsAt: frame
	| rcvr actionList index msg result |
	actionList := actions at: frame ifAbsent:[^self].
	index := 1.
	rcvr := self.
	[index <= actionList size] whileTrue:[
		msg := actionList at: index.
"Transcript cr; print: msg selector; space; print: msg arguments; endEntry."
		msg selector == #actionTarget:
			ifTrue:[	rcvr := msg sentTo: self]
			ifFalse:[	result := msg sentTo: rcvr.
					result ifNotNil:[index := index + result]].
		index := index + 1].