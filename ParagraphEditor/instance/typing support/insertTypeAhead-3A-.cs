insertTypeAhead: typeAhead
	typeAhead position = 0 ifFalse:
		[self zapSelectionWith: (Text string: typeAhead contents emphasis: emphasisHere).
		typeAhead reset.
		self unselect]