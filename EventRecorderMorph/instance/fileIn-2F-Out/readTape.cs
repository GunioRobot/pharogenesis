readTape
	^ self readTape: (FillInTheBlank
							request: 'Tape to read'
							initialAnswer: 'tapeName.tape').