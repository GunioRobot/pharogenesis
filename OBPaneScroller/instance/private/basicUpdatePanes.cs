basicUpdatePanes
	panes := model ifNotNil: [model panes] ifNil: [Array new].		
	self clearPanes.
	panes do: [:ea | self pushPane: ea].
