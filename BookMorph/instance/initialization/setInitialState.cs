setInitialState
	self listDirection: #topToBottom;
	  wrapCentering: #topLeft;
	  hResizing: #shrinkWrap;
	  vResizing: #shrinkWrap;
	  layoutInset: 5.
	pageSize _ 160 @ 300.
	self enableDragNDrop