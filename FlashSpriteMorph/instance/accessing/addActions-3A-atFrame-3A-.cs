addActions: actionList atFrame: frame
	actions ifNil:[actions _ Dictionary new].
	actions at: frame put: actionList.