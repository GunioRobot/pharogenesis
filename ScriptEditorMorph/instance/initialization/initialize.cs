initialize

	super initialize.
	color _ ScriptingSystem colorBehindTiles.
	orientation _ #vertical.
	hResizing _ #spaceFill.
	vResizing _ #shrinkWrap.

	self setDefaultBorderCharacteristics.
	firstTileRow _ 1.  "index of first tile-carrying submorph"
	self addNewRow
