writeTape
	| args b |
	args _ (b _ self button: 'writeTape') isNil
				ifTrue: [#()]
				ifFalse: [b arguments].
	(args size > 0 and: [args first size > 0])
		ifTrue: [args first.
				self writeTape: args first]
		ifFalse: [(Smalltalk
					at: #RequestBoxMorph
					ifAbsent:
						[^ self writeTape:
							(FillInTheBlank
								request: 'Tape to write'
								initialAnswer: 'tapeName.tape')])
						request: 'Tape to write'
						respondTo: self
						selector: #writeTape:]