registeredToolsMenu
	| menu |
	menu := self menu: 'Other Tools'.
	menu defaultTarget: self.
	^ self fillIn: menu from: self class registeredOpenCommands.
	