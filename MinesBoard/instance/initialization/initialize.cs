initialize
	"initialize the state of the receiver"
	super initialize.
	""
	target _ nil.
	actionSelector _ #selection.
	arguments _ #().
	""
	self layoutPolicy: nil;
	  hResizing: #rigid;
	  vResizing: #rigid.
	""
	rows _ self preferredRows.
	columns _ self preferredColumns.
	flashCount _ 0.
	""
	self extent: self protoTile extent * (columns @ rows).
	self adjustTiles.
	self resetBoard