allChangeSetNames
	^ self gatherChangeSets collect: [:c | c name]