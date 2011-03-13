initialize
	| menuHandle |
	super initialize.
	isVMMenuBar := true.
	menus := Dictionary new.
	self rebuildFromVMInstalledMenu.
	self appendStandardWindowMenu: 0.
	self reworkFileMenu.
	self menuBar.
	menuHandle := self getMenuHandle: 3.
	self enableMenuItem: menuHandle item: 1.
	self enableMenuItem: menuHandle item: 3.
	self enableMenuItem: menuHandle item: 4.
	self enableMenuItem: menuHandle item: 5.
	self drawMenuBar.
