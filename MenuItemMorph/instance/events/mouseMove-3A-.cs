mouseMove: evt
	| m |
	m _ evt hand recipientForMouseDown: evt hand lastEvent.
	m == self
		ifTrue: [isSelected ifFalse: [m selectFromHand: evt hand]]
		ifFalse: [self deselectForNewMorph: m.
				((m isKindOf: MenuItemMorph) and: [m isInMenu]) ifTrue:
					[m selectFromHand: evt hand]].