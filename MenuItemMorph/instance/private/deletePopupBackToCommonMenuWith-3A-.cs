deletePopupBackToCommonMenuWith: menuOrMenuItem

	| m menuToKeepUp owningItem |
	(menuOrMenuItem isKindOf: MenuMorph)
		ifTrue: [m _ menuOrMenuItem]
		ifFalse: [
			(menuOrMenuItem isKindOf: MenuItemMorph)
				ifTrue: [m _ menuOrMenuItem owner]
				ifFalse: [^ self]].

	menuToKeepUp _ IdentitySet new.
	[m isKindOf: MenuMorph] whileTrue: [
		menuToKeepUp add: m.
		owningItem _ m popUpOwner.
		(owningItem isKindOf: MenuItemMorph)
			ifTrue: [m _ owningItem owner]
			ifFalse: [m _ nil]].

	m _ self owner.
	[m isKindOf: MenuMorph] whileTrue: [
		(menuToKeepUp includes: m) ifTrue: [^ self].
		m stayUp ifFalse: [m delete].
		(m popUpOwner isKindOf: MenuItemMorph) ifTrue: [m popUpOwner isSelected: false].
		owningItem _ m popUpOwner.
		(owningItem isKindOf: MenuItemMorph)
			ifTrue: [m _ owningItem owner]
			ifFalse: [m _ nil]].
