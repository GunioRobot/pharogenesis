initialize
	characters _ WriteStream on: String new.
	currentAttributes _ OrderedCollection new.
	currentRun _ 0.
	attributeValues _ WriteStream on: (Array new: 50).
	attributeRuns _ WriteStream on: (Array new: 50).	