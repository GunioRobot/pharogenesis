isCurrentlyTextual
	| first |
	^ submorphs size > 0 and: [((first _ submorphs first) isKindOf: StringMorph) or: [first isKindOf: TextMorph]]