canDetachSubMenu: hand

	| possibleTargets item |
	possibleTargets _ hand argumentOrNil morphsAt: hand targetOffset.
	item _ possibleTargets
		detect: [:each | each isKindOf: MenuItemMorph]
		ifNone: [^ false].
	^ item subMenu notNil
