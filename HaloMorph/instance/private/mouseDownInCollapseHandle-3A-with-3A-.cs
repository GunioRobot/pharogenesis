mouseDownInCollapseHandle: evt with: collapseHandle
	evt hand obtainHalo: self.
	self removeAllHandlesBut: collapseHandle.
	collapseHandle color: Color tan darker