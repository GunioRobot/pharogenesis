highlight
	| str |
	isHighlighted _ true.
	submorphs size > 0
		ifTrue:
			[((str _ submorphs first) isKindOf: StringMorph)
				ifTrue:
					[str color: self highlightColor]
				ifFalse:
					[self borderWidth: 1; borderColor: self highlightColor]]