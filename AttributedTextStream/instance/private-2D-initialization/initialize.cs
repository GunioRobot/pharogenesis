initialize
	characters _ WriteStream on: String new.
	currentAttributes _ OrderedCollection new.
	attributesChanged _ true.
	attributeRuns _ RunArray new.
	