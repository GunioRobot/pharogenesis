display: item  atRow: row on: canvas
	"display the given item at row row"
	| drawBounds |
	drawBounds := self drawBoundsForRow: row.
	drawBounds := drawBounds intersect: self bounds.
	item isText
		ifTrue: [ canvas drawString: item in: drawBounds font: (font emphasized: (item emphasisAt: 1)) color: (self colorForRow: row) ]
		ifFalse: [ canvas drawString: item in: drawBounds font: font color: (self colorForRow: row) ].