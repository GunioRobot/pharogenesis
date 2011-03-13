setPanel: aPanel 
	panel := aPanel.
	self subscribe.
	children := #().
	self clearSelection