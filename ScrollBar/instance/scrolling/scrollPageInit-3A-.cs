scrollPageInit: evt
	self resetTimer.
	self setNextDirectionFromEvent: evt.
	self scrollBarAction: #doScrollByPage.
	self startStepping.