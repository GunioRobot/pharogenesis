testEditMenuModifiersMacOnly
	| menuHandle menuItemModifiers |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemModifiers := interface getMenuItemModifiers: menuHandle item: self undoMenuItem.
	self should: [menuItemModifiers size = 1].
	self should: [menuItemModifiers includes: #command].


