moveRightOrDown: evt 
	selectedItem ifNotNil: 
			[selectedItem hasSubMenu 
				ifTrue: 
					[self selectSubMenu: evt.
					selectedItem subMenu moveDown: evt]
				ifFalse: [self moveDown: evt]]