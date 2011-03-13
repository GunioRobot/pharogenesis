initialize
	super initialize.
	target _ nil.
	actionSelector _ #selection.
	arguments _ #().
	self layoutPolicy: nil.
	self hResizing: #rigid.
	self vResizing: #rigid.
	borderWidth _ 2.
	borderColor _ Color black.
	rows _ self preferredRows.
	columns _ self preferredColumns.
	color _ Color gray.
	palette _ (Color wheel: self preferredTileTypes + 1) asOrderedCollection.
	flashColor _ palette removeLast.
	flash _ false.
	self extent: self protoTile extent * (columns @ rows).
	self resetBoard.