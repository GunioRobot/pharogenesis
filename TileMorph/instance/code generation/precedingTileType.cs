precedingTileType
	"Return the slot reference type of the preceding TileMorph in my owner."

	| row i tile |
	row _ owner submorphs.
	i _ row indexOf: self.
	((i > 1) and: [(tile _ row at: i - 1) isKindOf: TileMorph])
		ifTrue: [^ tile type]
		ifFalse: [^ #unknown].
