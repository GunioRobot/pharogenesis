drawSelectionOn: aCanvas
	| selectionDrawBounds |
	selectedRow ifNil: [ ^self ].
	selectedRow = 0 ifTrue: [ ^self ].
	selectionDrawBounds := self drawBoundsForRow: selectedRow.
	selectionDrawBounds := selectionDrawBounds intersect: self bounds.
	aCanvas fillRectangle: selectionDrawBounds color: (Color lightGray  alpha: 0.3)