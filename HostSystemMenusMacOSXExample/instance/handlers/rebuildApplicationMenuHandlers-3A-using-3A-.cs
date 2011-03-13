rebuildApplicationMenuHandlers: aMenuRef using: aMenuBarMgr
	| maximumItems applicationMenuItemsTitles applicationMenuItems m |

	maximumItems := aMenuBarMgr countMenuItems: aMenuRef.
	applicationMenuItemsTitles := (1 to: maximumItems) collect: [:i | aMenuBarMgr getMenuItemText: aMenuRef item: i]. 	
	applicationMenuItems := applicationMenuItemsTitles collect: [:e | HostSystemMenusMenuItem menuString: e].
	applicationQuitMenuItem := applicationMenuItems detect: [:e | e text = 'Quit Example'] ifNone: [nil].
	applicationQuitMenuItem ifNotNil: [applicationQuitMenuItem handler: [self halt]].
	m := Dictionary new.
	applicationMenuItems doWithIndex:[:e :i | m at: i put: e].
	aMenuBarMgr menus at: (aMenuBarMgr getMenuID: aMenuRef) put: m.

