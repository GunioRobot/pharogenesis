addViewHandle: haloSpec
	self addHandle: haloSpec
		on: #mouseDown send: #openViewerForArgument to: innerTarget


