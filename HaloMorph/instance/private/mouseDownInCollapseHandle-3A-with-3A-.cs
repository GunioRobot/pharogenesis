mouseDownInCollapseHandle: evt with: collapseHandle
	self removeAllHandlesBut: collapseHandle.
	collapseHandle color: Color tan darker