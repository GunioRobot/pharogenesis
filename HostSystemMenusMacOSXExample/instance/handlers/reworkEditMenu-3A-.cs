reworkEditMenu: aMenuBarMgr
	| items editMenuID editMenu n |

	editMenuID := 3.
	editMenu := aMenuBarMgr getMenuHandle: editMenuID.
	items := OrderedCollection new.
		items add: (HostSystemMenusMenuItem menuString: 'Undo' keyboardKey: $z virtualKeyValue: 6);
		add: (HostSystemMenusMenuItem menuString: '-');
		add: (HostSystemMenusMenuItem menuString: 'Cut' keyboardKey: $x virtualKeyValue: 7);
		add: (HostSystemMenusMenuItem menuString: 'Copy' keyboardKey: $c virtualKeyValue: 8);
		add: (HostSystemMenusMenuItem menuString: 'Paste' keyboardKey: $v virtualKeyValue: 9);
		add: (HostSystemMenusMenuItem menuString: 'Clear').
	n := aMenuBarMgr countMenuItems: editMenu.
	n to: 1 by: -1 do: [:i | aMenuBarMgr deleteMenuItem: editMenu item: i].
	aMenuBarMgr appendMenu: editMenu menuItems: items.	
	editMenu := aMenuBarMgr getMenuHandle: editMenuID.
	n := aMenuBarMgr countMenuItems: editMenu.
	1 to: n by: 1 do: [:j | aMenuBarMgr enableMenuItem: editMenu item: j].
