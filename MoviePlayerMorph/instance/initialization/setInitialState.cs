setInitialState
	super setInitialState.
""
	self layoutInset: 3.
	pageSize _ frameSize _ 200 @ 200.
	frameDepth _ 8.
	self disableDragNDrop