drawBackgroundForMulti: row on: aCanvas
	| selectionDrawBounds |
	"shade the background darker, if this row is selected"

	selectionDrawBounds := self drawBoundsForRow: row.
	selectionDrawBounds := selectionDrawBounds intersect: self bounds.
	aCanvas fillRectangle: selectionDrawBounds color:  self color muchLighter