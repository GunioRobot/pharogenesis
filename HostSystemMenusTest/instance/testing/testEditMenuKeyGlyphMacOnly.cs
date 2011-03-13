testEditMenuKeyGlyphMacOnly
	| menuHandle menuItemKeyGlyph |

	self isMacintosh ifFalse: [^self].
	menuHandle := interface getMenuHandle: self fileMenu.
	menuItemKeyGlyph := interface getMenuItemKeyGlyph: menuHandle item: self undoMenuItem.
	self should: [menuItemKeyGlyph = 0].

