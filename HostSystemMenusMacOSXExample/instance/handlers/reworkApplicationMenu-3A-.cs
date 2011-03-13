reworkApplicationMenu: aMenuBarMgr
	| menuRef commandID menuItemIndex |

	commandID := MacOSType buildOSTypeFromCharString: 'hide'.
	menuRef := aMenuBarMgr getIndMenuWithCommandID: 0 item: commandID.
	menuItemIndex := aMenuBarMgr getIndMenuItemWithCommandID: 0 item: commandID.
	aMenuBarMgr setItemCmd: menuRef item: menuItemIndex cmdChar: $H.
	self rebuildApplicationMenuHandlers: menuRef using: aMenuBarMgr.
	commandID := MacOSType buildOSTypeFromCharString: 'quit'.
	aMenuBarMgr  enableMenuCommand: menuRef command: commandID.
	commandID := MacOSType buildOSTypeFromCharString: 'abou'.
	aMenuBarMgr  enableMenuCommand: menuRef command: commandID.


