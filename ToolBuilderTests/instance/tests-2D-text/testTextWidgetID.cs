testTextWidgetID
	self makeText.
	self assert: (builder widgetAt: #text) == widget