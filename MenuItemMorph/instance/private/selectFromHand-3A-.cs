selectFromHand: aHand

	self isSelected: true.
	aHand newMouseFocus: self.
	subMenu ifNotNil: [
		subMenu delete.
		subMenu
			popUpAdjacentTo: (Array with: self bounds topRight + (10@0)
									with: self bounds topLeft)
			forHand: aHand
			from: self].
