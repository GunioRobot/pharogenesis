readTape
	(Smalltalk
		at: #RequestBoxMorph
		ifAbsent:
			[^ self readTape:
				(FillInTheBlank
					request: 'Tape to read'
					initialAnswer: 'tapeName.tape')])
		request: 'Tape to read'
		respondTo: self
		selector: #readTape: