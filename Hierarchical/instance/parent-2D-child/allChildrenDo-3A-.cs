allChildrenDo: aBlock
	"Execute aBlock for all children of the receiver"
	myChildren do:[:child|
		aBlock value: child.
		child allChildrenDo: aBlock].