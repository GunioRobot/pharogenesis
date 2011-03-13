setInitialState
	self listDirection: #topToBottom.
	self wrapCentering: #topLeft.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self layoutInset: 5.
	color _ Color white.
							"pageSize _ 1060@800."
	pageSize _ 160@300.		"back to the original since the pother was way too big"
	self enableDragNDrop