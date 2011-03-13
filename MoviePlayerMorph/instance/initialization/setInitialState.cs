setInitialState
	super setInitialState.
	self layoutInset: 3.
	self borderWidth: 2.
	self color: Color veryLightGray.
	pageSize _ frameSize _ 200@200.
	frameDepth _ 8.
	self disableDragNDrop