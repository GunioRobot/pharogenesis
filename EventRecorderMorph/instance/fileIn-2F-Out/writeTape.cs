writeTape
	| args b |
	args := (b := self button: 'writeTape') isNil 
				ifTrue: [#()]
				ifFalse: [b arguments].
	(args notEmpty and: [args first notEmpty]) 
		ifTrue: 
			[args first.
			self writeTape: args first]
		ifFalse: 
			[^self writeTape: (FillInTheBlank request: 'Tape to write'
								initialAnswer: 'tapeName.tape')].