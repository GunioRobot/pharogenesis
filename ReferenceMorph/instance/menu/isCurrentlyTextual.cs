isCurrentlyTextual
	| first |
	^ ((first _ submorphs first) isKindOf: StringMorph) or: [first isKindOf: TextMorph]
		