createMenuItem: triplet on: menu 
	| wording help selectorOrMenu |
	wording := triplet first.
	help := triplet second.
	selectorOrMenu := triplet size > 3
				ifTrue: [triplet fourth]
				ifFalse: [self selectorForWording: wording].
	""
	selectorOrMenu isSymbol
		ifTrue: [""
			menu
				add: wording translated
				target: self
				selector: selectorOrMenu]
		ifFalse: [menu add: wording translated subMenu: selectorOrMenu].
	""
	help isNil
		ifFalse: [menu lastItem setBalloonText: help translated].""
	Preferences tinyDisplay
		ifFalse: [triplet size > 2
				ifTrue: [menu lastItem icon: triplet third]]