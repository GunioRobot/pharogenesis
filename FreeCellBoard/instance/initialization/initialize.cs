initialize

	super initialize.
	orientation := #vertical.
	hResizing _ #shrinkWrap.
	vResizing _ #rigid.
	self height: 500.
	borderWidth _ 0.
	color _ Color green.
	self layout.
