mouseMove: evt

	| m |
	m _ evt hand recipientForMouseDown: evt.
	m == self
		ifTrue: [isSelected ifFalse: [self isSelected: true]]
		ifFalse: [
			self deselectForNewMorph: m.
			((m isKindOf: MenuItemMorph) and: [m isInMenu]) ifTrue: [
				m selectFromHand: evt hand]].
"xxx
	m == self ifFalse: [
		((m isKindOf: MenuItemMorph) and: [m isInMenu]) ifTrue: [
			m owner == subMenu
				ifFalse: [self isSelected: false hand: evt hand].
			m isSelected: true hand: evt hand.
			evt hand newMouseFocus: m]].
xxx"
"xxx
	m == self ifTrue: [^ self].
	((m isKindOf: MenuItemMorph) and: [m isInMenu]) ifTrue: [
		m isSelected: true hand: evt hand.
		menu _ m owner.
		(menu == self owner or: [
		 menu == subMenu or: [
		 menu hasSubMenu: owner]]) ifTrue: [
			menu == subMenu ifFalse: [self hideSubmenu].
			(menu == self owner or: [m subMenu == owner or: [menu == subMenu]])
				ifFalse: [owner delete].
			evt hand newMouseFocus: m]].
xxx"
