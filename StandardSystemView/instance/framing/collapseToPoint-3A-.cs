collapseToPoint: collapsePoint
	self collapse.
	self align: self displayBox topLeft with: collapsePoint.
	collapsedViewport _ self viewport.
	self displayEmphasized