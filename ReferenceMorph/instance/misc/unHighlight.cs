unHighlight
	| str |
	isHighlighted _ false.
	self borderWidth: 0.
	submorphs size > 0
		ifTrue:
			[((str _ submorphs first) isKindOf: StringMorph orOf: RectangleMorph)
				ifTrue:
					[str color: self regularColor]]