selectFromHand: aHand

	isSelected _ true.
	self changed.
	aHand newMouseFocus: self.
	subMenu ifNotNil: [
		subMenu delete.
		subMenu popUpAt: self bounds topRight forHand2: aHand.
		subMenu popUpOwner: self].
