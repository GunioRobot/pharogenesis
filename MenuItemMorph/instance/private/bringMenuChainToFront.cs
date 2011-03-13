bringMenuChainToFront

	| menusToPopUp menu owningItem |
	menusToPopUp _ OrderedCollection new.
	menu _ self owner.
	[menu isKindOf: MenuMorph] whileTrue: [
		menusToPopUp addFirst: menu.
		owningItem _ menu popUpOwner.
		(owningItem isKindOf: MenuItemMorph)
			ifTrue: [menu _ owningItem owner]
			ifFalse: [menu _ nil]].
	menusToPopUp do: [:m | m owner addMorphFront: m].
