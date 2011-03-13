processListIndex: index 
	processListIndex _ index.
	selectedProcess _ processList
				at: index
				ifAbsent: [].
	self updateStackList.
	self changed: #processListIndex.