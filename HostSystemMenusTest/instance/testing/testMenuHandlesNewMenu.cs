testMenuHandlesNewMenu
	| menuString |

	menuString := 'Foobar'.
	secondaryMenu := interface newMenu: 6 menuTitle: menuString.
	interface insertMenu: secondaryMenu beforeID: 0.
	interface drawMenuBar: 1.
	self should: [(interface getMenuTitle: secondaryMenu) = menuString].
	interface deleteMenu: secondaryMenu.
	self should: [(interface getMenuHandle: 6) = 0].
	secondaryMenu := nil

	

