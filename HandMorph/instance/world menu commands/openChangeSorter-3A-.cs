openChangeSorter: oneOrTwo
	oneOrTwo = 1
		ifTrue: [ChangeSorter new morphicWindow openInWorld: self world]
		ifFalse: [DualChangeSorter new morphicWindow openInWorld: self world]