initialize

	super initialize.
	color _ Color paleYellow.
	self borderColor: Color black.
	self borderWidth: 1.
	self layoutPolicy: TableLayout new.
	self listDirection: #leftToRight.
	self wrapCentering: #topLeft.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self layoutInset: 2.
	self rubberBandCells: true. "default"