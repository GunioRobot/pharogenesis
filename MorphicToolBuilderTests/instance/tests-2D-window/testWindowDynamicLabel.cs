testWindowDynamicLabel
	self makeWindow.
	self assert: (widget label = 'TestLabel').