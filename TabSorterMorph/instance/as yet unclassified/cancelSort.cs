cancelSort
	| oldOwner |
	oldOwner _ owner.
	self delete.
	oldOwner addMorphFront: book