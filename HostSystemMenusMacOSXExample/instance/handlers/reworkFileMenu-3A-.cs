reworkFileMenu: aMenuBarMgr
| items fileMenuID fileMenu n |

	fileMenuID := 2.
	fileMenu := aMenuBarMgr getMenuHandle: fileMenuID.
	items := OrderedCollection new.
	items add:  (HostSystemMenusMenuItem menuString: 'Quit do not save').
	n := aMenuBarMgr countMenuItems: fileMenu.
	n to: 1 by: -1 do: [:i | aMenuBarMgr deleteMenuItem: fileMenu item: i].
	aMenuBarMgr appendMenu: fileMenu menuItems: items.	