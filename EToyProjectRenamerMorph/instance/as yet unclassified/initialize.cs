initialize

	super initialize.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	self setColorsAndBorder.
	self rebuild.
