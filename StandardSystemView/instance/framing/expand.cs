expand
	"If the receiver is collapsed, change its view to be that of all of its subviews, not its label alone."
	| newFrame |
	self isCollapsed
		ifTrue:
			[newFrame _ self chooseFrame expandBy: borderWidth.
			collapsedViewport _ self viewport.
			subViews _ savedSubViews.
			labelFrame borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
			savedSubViews _ nil.
			self setWindow: nil.
			self resizeTo: newFrame.
			self displayDeEmphasized.
			model modelWakeUpIn: self]