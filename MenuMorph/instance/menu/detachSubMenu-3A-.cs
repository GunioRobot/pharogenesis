detachSubMenu: evt

	| possibleTargets item subMenu |
	possibleTargets _ evt hand argumentOrNil morphsAt: evt hand targetOffset.
	item _ possibleTargets detect: [:each | each isKindOf: MenuItemMorph] ifNone: [^ self].
	subMenu _ item subMenu.
	subMenu ifNotNil: [
		item subMenu: nil.
		item delete.
		subMenu stayUp: true.
		subMenu popUpOwner: nil.
		subMenu addTitle: item contents.
		evt hand attachMorph: subMenu].
