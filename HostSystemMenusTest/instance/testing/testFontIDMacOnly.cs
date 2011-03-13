testFontIDMacOnly
	"menuItemFontID value is set by VM"
	| menuHandle menuItemFontID |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self applicationFirstMenu.
	menuItemFontID := interface getMenuItemFontID: menuHandle item: self arbitraryMenuItem.
	self should: [menuItemFontID = 0].

