getMenu: shiftKeyState

	| menu |

	self flag: #convertToBook.	"<-- no longer used"

	menu _ MenuMorph new defaultTarget: self.
	self addGeeMailMenuItemsTo: menu.
	^menu