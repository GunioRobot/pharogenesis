initialize
	"initialize the state of the receiver"
	super initialize.
	target _ nil.
	actionSelector _ #selection.
	arguments _ #().
	self layoutPolicy: nil.
	self hResizing: #rigid.
	self vResizing: #rigid.
	rows _ self preferredRows.
	columns _ self preferredColumns.

	palette _ (Color wheel: self preferredTileTypes + 1) asOrderedCollection.
	flashColor _ palette removeLast.
	flash _ false.
	self extent: self protoTile extent * (columns @ rows).
	self resetBoard