execute
	self workingCopies do: [ :workingCopy |
		workingCopy needsSaving
			ifTrue: [ self execute: workingCopy ] ]