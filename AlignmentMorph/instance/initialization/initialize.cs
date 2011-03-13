initialize

	super initialize.
	borderWidth _ 0.
	self layoutPolicy: TableLayout new.
	self listDirection: #leftToRight.
	self wrapCentering: #topLeft.
	self hResizing: #spaceFill.
	self vResizing: #spaceFill.
	self layoutInset: 2.
	color _ Color r: 0.8 g: 1.0 b: 0.8.
	self rubberBandCells: true. "default"