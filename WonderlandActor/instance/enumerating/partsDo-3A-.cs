partsDo: aBlock
	"Evaluate aBlock with all elements of the receiver that are a part of it"
	myChildren do:[:child| child isPart ifTrue:[aBlock value: child]].