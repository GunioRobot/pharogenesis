saveStateOf: aStream

	| inst |
	inst :=  state clone.
	inst streamPosition: aStream position.
	^ inst.
