initialize
	super initialize.
	saved _ true.
	borderWidth _ 2.
	borderColor _ #raised.
	color _ Color red.
	orientation _ #vertical.
	centering _ #center.
	hResizing _ #shrinkWrap.
	vResizing _ #shrinkWrap.
	inset _ 2.
	minCellSize _ 4.
	self addButtons.
