testTreeWidgetID
	self makeTree.
	self assert: (builder widgetAt: #tree) == widget.