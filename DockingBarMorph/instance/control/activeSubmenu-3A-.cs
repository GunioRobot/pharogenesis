activeSubmenu: aSubmenu 
	activeSubMenu isNil
		ifFalse: [activeSubMenu delete].
	activeSubMenu := aSubmenu.
	aSubmenu isNil
		ifTrue: [^ self].
	""
	activeSubMenu selectItem: nil event: nil.
	MenuIcons decorateMenu: activeSubMenu.
	activeSubMenu activatedFromDockingBar: self.
	activeSubMenu borderColor: self borderColor.
	activeSubMenu beSticky.
	activeSubMenu resistsRemoval: true.
activeSubMenu removeMatchString.