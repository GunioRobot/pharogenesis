displayView
	"Refer to the comment in View|displayView. "
	| label |
	self displayBox width = labelFrame width ifFalse:
		["recompute label width when window changes size"
		self setLabelRegion].
	label _ labelFrame
			align: (self isCollapsed
				ifTrue: [labelFrame topLeft]
				ifFalse: [labelFrame bottomLeft])
			with: self displayBox topLeft.
	label insideColor: self labelColor;
		displayOn: Display.
	self displayLabelText