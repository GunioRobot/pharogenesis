insertTypeAhead: typeAhead

	typeAhead isEmpty ifFalse:
		[self zapSelectionWith: 
			(Text string: typeAhead contents emphasis: emphasisHere).
		typeAhead reset.
		startBlock _ stopBlock copy]