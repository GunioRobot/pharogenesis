addActions: actionList atFrame: frame
	actions ifNil:[actions := Dictionary new].
	actions at: frame put: actionList.