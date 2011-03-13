testPanelWidgetID
	self makePanel.
	self assert: (builder widgetAt: #panel) == widget.