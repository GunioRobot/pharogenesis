step

	| newColor |
	selection ifNotNil:
		[newColor _ flash
			ifTrue: [selectionColor]
			ifFalse: [flashColor].
		selection do: [:loc | (self tileAt: loc) color: newColor].
		flash _ flash not]
