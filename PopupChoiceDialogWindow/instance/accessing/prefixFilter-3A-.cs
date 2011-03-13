prefixFilter: anObject
	"Set the value of prefixFilter"

	|found|
	found := false.
	prefixFilter := anObject.
	self changed: #prefixFilter.
	(self choiceMenus ifNil: [^self]) do: [:embeddedMenu |
		embeddedMenu selectItem: nil event: nil]. "clear selection in other menus"
	self choiceMenus do: [:embeddedMenu | 
		(embeddedMenu selectPrefix: self prefixFilter asLowercase)
			ifNotNilDo: [:menuItem |
				found ifFalse: [
					embeddedMenu selectItem: menuItem event: nil.
					self activeHand newKeyboardFocus: embeddedMenu.
					found := true]]]