removeItem: evt

	| possibleTargets item |
	possibleTargets _ evt hand argumentOrNil morphsAt: evt hand targetOffset.
	item _ possibleTargets
		detect: [:each |
					(each isKindOf: MenuItemMorph) or:
					 [each isKindOf: MenuLineMorph]]
		ifNone: [^ self].
	item delete.
