hideSubmenu

	subMenu ifNotNil: [subMenu deleteIfPopUp].
	(owner isKindOf: MenuMorph) ifTrue: [owner deleteIfPopUp].
