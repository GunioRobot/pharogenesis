initialize

	super initialize.
	color _ ScriptingSystem colorBehindTiles.
	self listDirection: #topToBottom.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.

	self setDefaultBorderCharacteristics.
	firstTileRow _ 1.  "index of first tile-carrying submorph"
	self addNewRow.
	showingMethodPane _ false.