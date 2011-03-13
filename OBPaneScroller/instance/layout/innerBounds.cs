innerBounds
	| rect |
	rect _ super innerBounds.
	^ self scrollBarIsVisible
		ifTrue: [rect withHeight: rect height - self scrollBarHeight - 1]
		ifFalse: [rect]