testEncodingMacOnly
	"menuItemTextEncoding value is set by VM"
	| menuHandle menuItemTextEncoding |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self applicationFirstMenu.
	menuItemTextEncoding := interface getMenuItemTextEncoding: menuHandle item: self arbitraryMenuItem.
	self should: [menuItemTextEncoding isZero not ]. 

