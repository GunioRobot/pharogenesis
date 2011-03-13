canDetachSubMenu: hand
	| possibleTargets item arg |
	(arg _ hand argumentOrNil) ifNil: [^ false].
	possibleTargets _ arg morphsAt: hand targetOffset.
	item _ possibleTargets
		detect: [:each | each isKindOf: MenuItemMorph]
		ifNone: [^ false].
	^ item subMenu notNil
