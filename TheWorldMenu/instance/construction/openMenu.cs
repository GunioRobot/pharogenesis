openMenu
	"Build the open window menu for the world."

	| menu |
	menu := MenuMorph new.
	menu defaultTarget: ToolSet default.
	menu addList: ToolSet menuItems.
	menu defaultTarget: self.
	^ self fillIn: menu from: {nil. {'more...'. {self. #registeredToolsDo}}}