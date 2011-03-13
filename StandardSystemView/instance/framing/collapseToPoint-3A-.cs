collapseToPoint: collapsePoint
	self collapse.
	self align: self displayBox topLeft with: collapsePoint.
	collapsedViewport := self viewport.
	self displayEmphasized