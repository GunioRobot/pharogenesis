drawOn: aCanvas

	| dot row1 row2 offset |
	super drawOn: aCanvas.   "Draw square board"

	"Only draw rows in the clipping region"
	dot _ Form dotOfSize: self width//25.
	offset _ self pieceSize - dot extent + 1 // 2.  "Offset of smaller dots rel to larger"
	row1 _ (self boardLocAt: aCanvas clipRect topLeft) x max: 1.
	row2 _ (self boardLocAt: aCanvas clipRect bottomRight) x min: board size.
	row1 to: row2 do:
		[:row | (board at: row) doWithIndex:
			[:cell :i | cell ifNotNil:
				[aCanvas stencil: dot
					at: (self cellPointAt: (row@i)) + offset
					color: (colors at: cell+1)]]]