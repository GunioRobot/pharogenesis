drawOn: aCanvas 

	| row1 row2 offset dotExtent |
	super drawOn: aCanvas.   "Draw square board"

	"Only draw rows in the clipping region"
	dotExtent _ (self width//25) asPoint.
	offset _ self pieceSize - dotExtent + 1 // 2.  "Offset of smaller dots rel to larger"
	row1 _ (self boardLocAt: aCanvas clipRect topLeft) x max: 1.
	row2 _ (self boardLocAt: aCanvas clipRect bottomRight) x min: board size.
	row1 to: row2 do:
		[:row | (board at: row) doWithIndex:
			[:cell :i | cell ifNotNil:
				[aCanvas fillOval: ((self cellPointAt: (row@i)) + offset extent: dotExtent)
					color: (colors at: cell+1)]]]