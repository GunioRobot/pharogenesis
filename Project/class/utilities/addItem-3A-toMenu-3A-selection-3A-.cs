addItem: item toMenu: menu selection: action
	(menu isKindOf: MenuMorph)
		ifTrue: [menu add: item selector: #jumpToSelection: argument: action]
		ifFalse: [menu add: item action: action]