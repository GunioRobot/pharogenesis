testKeyGlyphMacOnly
	"menuItemKeyGlyph value is set by VM"
	| menuHandle menuItemKeyGlyph |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self applicationFirstMenu.
	menuItemKeyGlyph := interface getMenuItemKeyGlyph: menuHandle item: self arbitraryMenuItem.
	self should: [menuItemKeyGlyph = 0].

