testEditMenuEncodingMacOnly
	| menuHandle menuItemTextEncoding |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self editMenu.
	menuItemTextEncoding := interface getMenuItemTextEncoding: menuHandle item: self arbitraryMenuItem.
	self should: [menuItemTextEncoding = 4294967294 ].

