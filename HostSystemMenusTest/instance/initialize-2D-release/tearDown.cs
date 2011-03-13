tearDown
	secondaryMenu ifNotNil: [interface deleteMenu: secondaryMenu].
	subMenu ifNotNil: [interface deleteMenu: subMenu]