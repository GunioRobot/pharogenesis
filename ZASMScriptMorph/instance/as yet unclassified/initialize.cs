initialize

	somethingChanged _ true.
	super initialize.
	self dragEnabled: true.
	borderWidth _ 2.
	self layoutPolicy: TableLayout new.
	self listDirection: #topToBottom.
	self wrapCentering: #topLeft.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self layoutInset: 6.
	color _ Color lightBlue.
	self borderColor: Color blue.
	self rubberBandCells: true. "default"