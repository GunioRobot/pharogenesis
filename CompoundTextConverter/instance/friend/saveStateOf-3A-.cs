saveStateOf: aStream

	| inst |
	inst _  state clone.
	inst streamPosition: aStream position.
	^ inst.
