select: evt
	self isSelected: true.
	owner activeSubmenu: subMenu.
	subMenu ifNotNil: [
		subMenu delete.
		subMenu
			popUpAdjacentTo: (Array with: self bounds topRight + (10@0)
									with: self bounds topLeft)
			forHand: evt hand
			from: self.
		subMenu selectItem: nil event: evt].