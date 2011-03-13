superiorsDo: aBlock
	| cursor |
	cursor := superior.
	[cursor isNil] whileFalse:
		[aBlock value: cursor.
		cursor := cursor superior]