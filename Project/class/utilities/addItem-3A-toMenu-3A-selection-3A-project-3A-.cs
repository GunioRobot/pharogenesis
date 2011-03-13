addItem: item toMenu: menu selection: action project: aProject 
	| color |
	color := aProject isMorphic
				ifTrue: [aProject world isInMemory
						ifTrue: [Color black]
						ifFalse: [Color brown]]
				ifFalse: [aProject world isInMemory
						ifTrue: [Color veryVeryDarkGray]
						ifFalse: [Color blue]].
	(menu isKindOf: MenuMorph)
		ifTrue: [| thumbnail | 
			menu
				add: item
				selector: #jumpToSelection:
				argument: action.
			menu lastItem color: color.
			thumbnail := aProject thumbnail.
			thumbnail isNil
				ifFalse: [menu lastItem
						icon: (thumbnail scaledIntoFormOfSize: (Preferences tinyDisplay ifTrue: [16] ifFalse: [28]))]]
		ifFalse: [menu add: item action: action]