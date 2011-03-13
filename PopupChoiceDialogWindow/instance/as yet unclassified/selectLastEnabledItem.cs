selectLastEnabledItem
	"Select the last enabled item in any of the embedded menus"

	|found|
	found := false.
	(self choiceMenus ifNil: [^self]) do: [:embeddedMenu |
		embeddedMenu selectItem: nil event: nil]. "clear selection in other menus"
	self choiceMenus reverseDo: [:embeddedMenu | 
		(embeddedMenu selectLastPrefix: self prefixFilter)
			ifNotNilDo: [:menuItem |
				found ifFalse: [
					embeddedMenu selectItem: menuItem event: nil.
					self activeHand newKeyboardFocus: embeddedMenu.
					found := true]]]