withAllChildrenDo: aBlock
	"Execute aBlock for all children of and the receiver itself"
	aBlock value: self.
	myChildren do:[:child|
		child withAllChildrenDo: aBlock.
	].