allPartsDo: aBlock
	"Recursively evaluate aBlock with all elements of the receiver that are a part of its parent"
	self partsDo:[:child|
		aBlock value: child.
		child allPartsDo: aBlock]