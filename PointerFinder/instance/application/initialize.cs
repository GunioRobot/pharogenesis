initialize
	parents _ IdentityDictionary new: 20000.
	parents at: Smalltalk put: nil.
	parents at: Processor put: nil.
	parents at: self put: nil.

	toDo _ OrderedCollection new: 5000.
	toDo add: Smalltalk.
	toDoNext _ OrderedCollection new: 5000