lastItem
	^ submorphs reverse
		detect: [ :m | m isKindOf: MenuItemMorph ]
		ifNone: [ submorphs last ]