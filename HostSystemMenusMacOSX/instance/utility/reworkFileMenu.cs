reworkFileMenu 
	| menuRef |

	menuRef := self findApplicationMenuViaHideMenuItem.
	self rebuildApplicationMenuHandlers: menuRef.
	self disableApplicationHide: menuRef.
	self enableApplicationQuit: menuRef.
	self alterFileMenu.
	self alterAppMenu.
	self addMenus.
	
	