testMenuHandlesNewMenuAppendInsertItem
	| aItem checkBlock1 checkBlock2 block1 block2 |
	
	self testMenuHandlesNewMenuAppend.
	block1 := [:evt | Beeper beep].
	block2 := [:evt | Beeper beep. Beeper beep].
	aItem := HostSystemMenusMenuItem text: 'three' handler: block1.
	interface insertMenuItem: secondaryMenu item: aItem afterItem: 1.
	aItem := HostSystemMenusMenuItem text: 'four' handler: block2.
	interface insertMenuItem: secondaryMenu item: aItem afterItem: 3.
	checkBlock1 := (HostSystemMenus 
		defaultMenuBarForWindowIndex: 1) getHandlerForMenu: 4 item: 2.
	checkBlock2 := (HostSystemMenus 
		defaultMenuBarForWindowIndex: 1)  getHandlerForMenu: 4 item: 4.
	self should: [checkBlock1 handler == block1 ].
	self should: [checkBlock2 handler == block2 ].
	self should: [(interface countMenuItems: secondaryMenu) = 4].
	self should: [(interface getMenuItemText: secondaryMenu item: 2) = 'three'].
	self should: [(interface getMenuItemText: secondaryMenu item: 4) = 'four']



	

