selectFromHand: aHand

	self isSelected: true.
	aHand newMouseFocus: self.
	subMenu ifNotNil: [
		subMenu delete.
		subMenu
			popUpAt: self bounds topRight + (10@0)
			forHand: aHand
			from: self].
