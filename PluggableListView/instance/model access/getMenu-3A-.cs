getMenu: shiftKeyDown
	"Answer the menu for this text view, supplying an empty menu to be filled in. If the menu selector takes an extra argument, pass in the current state of the shift key."
	| menu aMenu |
	getMenuSelector == nil ifTrue: [^ nil].
	menu _ CustomMenu new.
	getMenuSelector numArgs = 1
		ifTrue:
			[aMenu _ model perform: getMenuSelector with: menu.
			getMenuTitleSelector ifNotNil: [aMenu title: (model perform: getMenuTitleSelector)].
			^ aMenu].
	getMenuSelector numArgs = 2
		ifTrue: [aMenu _ model perform: getMenuSelector with: menu with: shiftKeyDown.
				getMenuTitleSelector ifNotNil: [aMenu title: (model perform: getMenuTitleSelector)].
				^ aMenu].
	^ self error: 'The getMenuSelector must be a 1- or 2-keyword symbol'