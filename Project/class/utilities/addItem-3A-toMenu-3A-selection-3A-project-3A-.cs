addItem: item toMenu: menu selection: action project: aProject
	| aColor |
	aColor _ aProject isMorphic 
		ifTrue: [aProject world isInMemory 
			ifTrue: [Color red darker] 
			ifFalse: [Color brown]]
		ifFalse: [aProject world isInMemory 
			ifTrue: [Color veryVeryDarkGray]
			ifFalse: [Color blue]].
	(menu isKindOf: MenuMorph)
		ifTrue:
			[menu add: item selector: #jumpToSelection: argument: action.
			menu items last color: aColor]
		ifFalse:
			[menu add: item action: action]