addCollapseHandle: handleSpec
	"we're hacking here - using mostly dismiss' infrastructure"
	| dismissHandle |
	dismissHandle _ self addHandle: handleSpec
		on: #mouseDown send: #mouseDownInCollapseHandle:with: to: self.
	dismissHandle on: #mouseUp send: #maybeCollapse:with: to: self.
	dismissHandle on: #mouseDown send: #setDismissColor:with: to: self.
	dismissHandle on: #mouseMove send: #setDismissColor:with: to: self.
